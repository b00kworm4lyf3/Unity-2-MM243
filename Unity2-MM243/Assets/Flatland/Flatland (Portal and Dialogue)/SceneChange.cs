using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public int sceneIndex;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Invoke("SceneLoadDelay", 5f);
        }
    }

    void SceneLoadDelay()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
