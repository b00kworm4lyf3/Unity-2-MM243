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
        if(other.CompareTag("Respawn")){
            StartCoroutine(Respawn());
        }

        else if(other.CompareTag("Checkpoint")){
            startPos = other.transform.position;
            startRot = other.transform.rotation;
            //other.gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject, 0.2f);
        }

        else if(other.CompareTag("Goal")){
            startPos = other.transform.position;
            startRot = other.transform.rotation;
            //other.gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject, 0.2f);
            StartCoroutine(Goal());
        }
    }

    IEnumerator Respawn(){
        DisableController();
        yield return new WaitForSeconds(0.2f);

        transform.SetPositionAndRotation(startPos, startRot);
        GetComponent<Animator>().Play("LOSE00");

        yield return new WaitForSeconds(3.283f);
        EnableController();

    }

    IEnumerator Goal(){
        DisableController();
        yield return new WaitForSeconds(0.2f);
        
        GetComponent<Animator>().Play("WIN00");

        yield return new WaitForSeconds(3.4f);
        EnableController();
    }

    void DisableController(){
        GetComponent<CharacterController>().enabled = false;
        GetComponent<ThirdPersonController>().enabled = false;
    }

    void EnableController(){
        GetComponent<ThirdPersonController>().enabled = true;
        GetComponent<CharacterController>().enabled = true;
    }
}
