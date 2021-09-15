using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutSceneScript : MonoBehaviour
{
    public VideoPlayer cutScene;
    private void Start()
    {
       
    }

    private void Update()
    {
        if (cutScene.isPlaying == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
