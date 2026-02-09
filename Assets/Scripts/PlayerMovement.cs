using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float jumpSpeed;

    [SerializeField]
    private float jumpHorizontalSpeed;

    [SerializeField]
    private float jumpButtonGracePeriod;

    [SerializeField]
    private Transform cameraTransform;

    private Animator animator;
    private CharacterController characterController;
    private float ySpeed;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;
    private bool isJumping;
    private bool isGrounded;
    private bool forcedBounce;

    private Ui_manager uiManager;

    #region (DISABLED) Ledge Grab Variables
    //[SerializeField]
    //private bool isFacingWall;
    //public Transform wallTarget;
    //public bool onLedge;

    //public GameObject rayhitLedgeMarker;
    //public Transform headHeight;
    //private Vector3 ledgeMarker;
    //private Vector3 rayStart;
    //private Vector3 rayLedgeStart;
    //public Vector3 playerOffset = new Vector3(0f, 0f, 0f);
    //public LayerMask ledgeDetectMask;
    //private RaycastHit rayHitwall;
    //private RaycastHit rayFindLedge;
    #endregion

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        uiManager = GetComponent<Ui_manager>();
    }

    void Update()
    {
        #region Custom CancelAction Input Test
        //if (Input.GetButtonDown("CancelAction")) 
        //{
        //    Debug.Log("Cancel Action Pressed");
        //}
        #endregion

        #region DEBUG - RESTART LEVEL
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level_Borgdahl_Alpha_01");
        }
        #endregion

        #region DEBUG - QUIT GAME

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        #endregion

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            uiManager.ToggleJournal();
        }



        if (!characterController.isGrounded)
        {
            forcedBounce = false;
        }

            //Debug.Log(characterController.velocity);

            #region Base Movement Inputs & Values
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
            float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                inputMagnitude /= 2;
            }

            animator.SetFloat("Input Magnitude", inputMagnitude, 0.05f, Time.deltaTime);

            movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
            movementDirection.Normalize();

            ySpeed += Physics.gravity.y * Time.deltaTime;
            #endregion

            #region Jumping & Falling Movement Handler

            if (characterController.isGrounded)
            {
                lastGroundedTime = Time.time;
            }

            if (Input.GetButtonDown("Jump"))
            {
                jumpButtonPressedTime = Time.time;
            }

            if (Time.time - lastGroundedTime <= jumpButtonGracePeriod) //!forcedBounce && 
        {
                //ySpeed = -0.5f;

                animator.SetBool("isGrounded", true);
                isGrounded = true;

                animator.SetBool("isJumping", false);
                isJumping = false;

                animator.SetBool("isFalling", false);

                if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
                {
                    ySpeed = jumpSpeed;
                    animator.SetBool("isJumping", true);
                    isJumping = true;

                    jumpButtonPressedTime = null;
                    lastGroundedTime = null;
                }
            }
            else
            {
                animator.SetBool("isGrounded", false);
                isGrounded = false;

                if ((isJumping && ySpeed < 0) || ySpeed < -2)
                {
                    animator.SetBool("isFalling", true);
                }

                // -- Ledge Grab Related Stuff --
                //if (onLedge)
                //{
                //    ySpeed = 0f;

                //    if (onLedge && Input.GetButtonDown("Jump"))
                //    {
                //        ySpeed = jumpSpeed;
                //        onLedge = false;
                //        animator.SetBool("isHanging", false);
                //    }

                //if (onLedge && Input.GetButtonDown("CancelAction"))
                //{
                //    onLedge = false;
                //    animator.SetBool("isHanging", false);
                //}
                //}
            }
            #endregion

            #region Movement Direction        

            if (movementDirection != Vector3.zero) // && !onLedge
            {
                animator.SetBool("isMoving", true);
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }

            else
            {
                animator.SetBool("isMoving", false);
            }

            #endregion

            #region Mid-Air Movement Override
            if (isGrounded == false) //&& !onLedge) 
            {
                Vector3 velocity = movementDirection * inputMagnitude * jumpHorizontalSpeed;
                velocity.y = ySpeed;

                characterController.Move(velocity * Time.deltaTime);
            }
            #endregion

        }

        #region Root Animation Driven Movement
        private void OnAnimatorMove()
        {
            if (isGrounded) // && !onLedge
            {
                Vector3 velocity = animator.deltaPosition;
                velocity = AdjustVelocityToSlope(velocity);     // - Part of Down-Slope Bounce Fix
                velocity.y += ySpeed * Time.deltaTime;
                characterController.Move(velocity);
            }
        }
        #endregion

        #region Fixing Down-Slope Bounce
        private Vector3 AdjustVelocityToSlope(Vector3 velocity)
        {
            var ray = new Ray(transform.position, Vector3.down);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, 0.2f))
            {
                var slopeRotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
                var adjustedVelocity = slopeRotation * velocity;

                if (adjustedVelocity.y < 0)
                {
                    return adjustedVelocity;
                }
            }
            return velocity;
        }
        #endregion

        #region Lock Mouse On Game Focus
        //private void OnApplicationFocus(bool focus)
        //{
        //    if (focus)
        //    {
        //        Cursor.lockState = CursorLockMode.Locked;
        //    }
        //    else
        //    {
        //        Cursor.lockState = CursorLockMode.None;
        //    }
        //}
        #endregion

        #region (DISABLED) Ledge-Grab Attempt 1 - Raycasts & Triggers 
        //private void FixedUpdate()
        //{
        //    LedgeRaycast();
        //    FacingWallCheck();
        //}

        //void LedgeRaycast()
        //{
        //    if (Physics.Raycast(headHeight.position, transform.forward, out rayHitwall, 1f, ledgeDetectMask))
        //    {
        //        rayStart = rayHitwall.point + transform.forward * 0.05f;
        //        rayStart.y += 3.0f; 

        //        if (Physics.Raycast(rayStart, Vector3.down, out rayFindLedge, 5f))
        //        {
        //            ledgeMarker = new Vector3(rayHitwall.transform.position.x, rayFindLedge.transform.position.y, rayHitwall.transform.position.z);
        //            GameObject TempLedgeMarker;
        //            TempLedgeMarker = Instantiate(rayhitLedgeMarker, rayFindLedge.point, Quaternion.LookRotation(rayFindLedge.normal));
        //            Destroy(TempLedgeMarker, 0.03f);
        //        }
        //    }
        //}

        //void LerpToLedge()
        //{
        //    Vector3 hitPosition = rayFindLedge.point;
        //    transform.position = Vector3.Lerp(transform.position, hitPosition, 1);
        //    transform.position = transform.TransformPoint(playerOffset);
        //}

        //void FacingWallCheck()
        //{
        //    RaycastHit hit;
        //    if (Physics.Raycast(wallTarget.position, transform.forward, out hit, 1.0f))
        //    {
        //        if (onLedge && isFacingWall)
        //        {
        //            transform.forward = -hit.normal;
        //        }
        //        isFacingWall = true;
        //    }
        //    else
        //    {
        //        isFacingWall = false;
        //    }

        //    Vector3 forward = transform.TransformDirection(Vector3.forward) * 1.0f;
        //    Debug.DrawRay(wallTarget.position, forward, Color.green, 1.0f);
        //}

        //private void OnTriggerEnter(Collider other)
        //{
        //    // Use a hidden object in front of player instead of raycast to check if colliding with a wall? 

        //    if (other != null && other.CompareTag("Ledge")) // if (other != null && other.CompareTag("Ledge") && isFacingWall) Not great to do isFacingWall check here, as it's only possible to connect when jumping upwards from under the ledge.
        //{
        //        print("Found Ledge");
        //        onLedge = true;
        //        animator.SetBool("isHanging", true);
        //    }
        //}

        //private void OnTriggerExit(Collider other)
        //{
        //    if(other != null && other.CompareTag("Ledge"))
        //    {
        //        print("Lost Ledge");
        //        onLedge = false;
        //        animator.SetBool("isHanging", false);
        //    }
        //}
        #endregion


        public void Bounce (float bounceForce)
    {
        //ySpeed = verticalSpeed;

        ySpeed = 0;
        ySpeed += bounceForce;
        //forcedBounce = true;

        lastGroundedTime = -999f;
        jumpButtonPressedTime = -999f;


        isGrounded = false;
        isJumping = true;

        animator.SetBool("isGrounded", false);
        animator.SetBool("isJumping", true);
        animator.SetBool("isFalling", false);

    }



    }
