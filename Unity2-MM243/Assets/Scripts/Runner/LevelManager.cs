using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour{
    Vector3 startPos;
    Quaternion startRot;

    // Start is called before the first frame update
    void Start(){
        startPos = transform.position;
        startRot = transform.rotation;
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Respawn"){
            GetComponent<CharacterController>().enabled = false;
            transform.position = startPos;
            transform.rotation = startRot;
            GetComponent<CharacterController>().enabled = true;
            GetComponent<Animator>().Play("LOSE00");
        }

        else if(other.tag == "Checkpoint"){
            startPos = other.transform.position;
            startRot = other.transform.rotation;
            Destroy(other.gameObject, 0.2f);
        }

        else if(other.tag == "Goal"){
            //GetComponent<CharacterController>().enabled = false;
            Destroy(other.gameObject, 0.2f);
            GetComponent<Animator>().Play("WIN00");
            //GetComponent<CharacterController>().enabled = true;
        }
    }
}
