using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{


    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("clicked");
    }

    public void GoNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
