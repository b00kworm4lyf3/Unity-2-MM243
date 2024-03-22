using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public int sceneToLoad = 1;
    public float timeDelay = 5;
    // Start is called before the first frame update
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Entered");
        if(other.gameObject.tag == "Player")
        {
            Invoke("LoadScene", 5);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
