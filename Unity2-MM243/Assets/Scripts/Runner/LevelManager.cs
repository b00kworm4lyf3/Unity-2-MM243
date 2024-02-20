using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

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
            StartCoroutine(Respawn());
        }

        else if(other.tag == "Checkpoint"){
            startPos = other.transform.position;
            startRot = other.transform.rotation;
            other.gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject, 0.5f);
        }

        else if(other.tag == "Goal"){
            startPos = other.transform.position;
            startRot = other.transform.rotation;
            other.gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject, 0.5f);
            StartCoroutine(Goal());
        }
    }

    IEnumerator Respawn(){
        GetComponent<CharacterController>().enabled = false;
        GetComponent<ThirdPersonController>().enabled = false;
        transform.position = startPos;
        transform.rotation = startRot;
        GetComponent<Animator>().Play("LOSE00");
        yield return new WaitForSeconds(3.283f);
        GetComponent<CharacterController>().enabled = true;
        GetComponent<ThirdPersonController>().enabled = true;

    }

    IEnumerator Goal(){
        GetComponent<CharacterController>().enabled = false;
        GetComponent<ThirdPersonController>().enabled = false;
        GetComponent<Animator>().Play("WIN00");
        yield return new WaitForSeconds(3.4f);
        GetComponent<ThirdPersonController>().enabled = true;
        GetComponent<CharacterController>().enabled = true;
    }
}
