using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlatlandManager : MonoBehaviour
{
    private int counter = 0;
    public int numApples = 3;
    public GameObject portal;
    public Camera main;

    // Update is called once per frame
    void Update(){
        if(counter >= numApples){
            StartCoroutine(EndGame());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            collision.gameObject.GetComponent<AppleFollow>().enabled = true;
            StartCoroutine(DisableCollider(collision));
            counter += 1;
            print(counter);
        }
    }

    private IEnumerator DisableCollider(Collision2D collision){
        yield return new WaitForSeconds(1);
        collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }

    IEnumerator EndGame(){
        portal.SetActive(true);
        counter = 0;
        yield return new WaitForSeconds(2);
        main.GetComponent<Animator>().SetBool("GameOver", true);
        GetComponent<PlayerInput>().enabled = false;
    }
}
