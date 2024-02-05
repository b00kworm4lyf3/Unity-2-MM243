using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimedSceneChange : MonoBehaviour{
    public float delaySeconds;
    public int sceneToLoad = 1;

    // Start is called before the first frame update
    void Start(){
        Invoke("SceneChange", delaySeconds);
    }

    void SceneChange(){
        SceneManager.LoadScene(sceneToLoad);
        return;
    }
}
