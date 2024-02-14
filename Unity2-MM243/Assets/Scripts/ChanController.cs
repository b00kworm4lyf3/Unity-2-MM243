using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanController : MonoBehaviour{
    Animator chanim;
    Rigidbody rb;
    float inputX;
    float inputY;
    bool run;
    // Start is called before the first frame update
    void Start(){
        chanim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            chanim.Play("WAIT01");
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)){
            chanim.Play("WAIT02");
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            chanim.Play("WAIT03");
        }

        if(Input.GetKeyDown(KeyCode.Alpha4)){
            chanim.Play("WAIT04");
        }

        if(Input.GetMouseButtonDown(0)){
            int n = Random.Range(0, 2);

            if(n == 0){
                chanim.Play("DAMAGED00");
            }
            
            if(n == 1){
                chanim.Play("DAMAGED01");
            }
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            chanim.Play("JUMP00");
        }

        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)){
            run = true;
        }
        else{
            run = false;
        }

        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        chanim.SetFloat("inputX", inputX);
        chanim.SetFloat("inputY", inputY);
        //chanim.SetBool("run", run);

        float moveX = inputX * 20f * Time.deltaTime;
        float moveZ = inputY * 50f * Time.deltaTime;

        if(moveZ <= 0){
            moveX = 0f;
            run = false;
        }

        chanim.SetBool("run", run);

        if(run == true){
            moveX *= 3f;
            moveZ *= 3f;
        }

        rb.velocity = new Vector3(moveX, 0, moveZ);
    }
}
