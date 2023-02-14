using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ResetScene : MonoBehaviour
{
    public static void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

}