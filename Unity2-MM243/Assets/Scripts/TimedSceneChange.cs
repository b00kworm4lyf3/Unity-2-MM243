using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimedSceneChange : MonoBehaviour{
    public float delaySeconds;

    // Start is called before the first frame update
    void Start(){
        StartCoroutine(SceneChange());
    }

    IEnumerator SceneChange(){
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene(1);
    }
}
