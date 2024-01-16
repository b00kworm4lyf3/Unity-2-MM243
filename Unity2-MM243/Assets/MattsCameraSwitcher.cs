using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MattsCameraSwitcher : MonoBehaviour{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            cam1.SetActive(true);
            cam2.SetActive(false);
            cam3.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)){
            cam1.SetActive(false);
            cam2.SetActive(true);
            cam3.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3)){
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(true);
        }
    }
}
