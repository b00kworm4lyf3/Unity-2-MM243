using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleFollow : MonoBehaviour{
    public float speed;
    private Transform target;
    public float offset = 1;
    // Start is called before the first frame update
    void Start(){
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update(){
        if(Vector2.Distance(transform.position, target.position) > offset){
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
