using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("Level_Borgdahl_Beta_01");
    }
}
