using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_scene : MonoBehaviour {

    public int preScene = 0;
    public int nextScene = 1;

    void OnTriggerStay2D(Collider2D other)
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.buildIndex == preScene && other.tag == "Player")
            SceneManager.LoadScene(nextScene);
        else
            SceneManager.LoadScene(preScene);

    }
}
