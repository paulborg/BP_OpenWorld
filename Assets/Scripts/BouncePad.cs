using UnityEngine;

public class BouncePad : MonoBehaviour
{

    public float bounceForce = 10f;


    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponentInParent<PlayerMovement>();
        if (player == null)
        return;

        player.Bounce(bounceForce);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
