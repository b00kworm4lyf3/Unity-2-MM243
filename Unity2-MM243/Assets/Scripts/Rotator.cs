using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour{
    public float yRotSpeed = 3;
    void FixedUpdate(){
        transform.Rotate(0, yRotSpeed, 0, Space.World);
    }
}
