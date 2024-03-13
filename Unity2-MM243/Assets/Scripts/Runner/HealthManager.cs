using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour{
    public Slider bar;
    public int barVal = 100;
    [SerializeField] int subVal = 10;
     public bool subtractVal = true;
    // Start is called before the first frame update
    void Start(){
        barVal = 100;
        bar.value = barVal;
        InvokeRepeating(nameof(SubtractBarVal), 3, 3);
    }

    // Update is called once per frame
    void Update(){
        if(barVal == 0){
            subtractVal = false;
            StartCoroutine(ResetHealth());
            LivesManager.lives--;
            print(LivesManager.lives);
            StartCoroutine(PlayerReborn("DAMAGED01"));
        }
    }

    void SubtractBarVal(){
        if(subtractVal == true){
            barVal -= subVal;
            barVal = Mathf.Clamp(barVal, 0, 100);
            bar.value = barVal;
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("GreenShroom")){
            barVal += 20;
            barVal = Mathf.Clamp(barVal, 0, 100);
            bar.value = barVal;
            Destroy(other.gameObject);
        }

        if(other.CompareTag("BlueShroom")){
            barVal += 5;
            barVal = Mathf.Clamp(barVal, 0, 100);
            bar.value = barVal;
            Destroy(other.gameObject);
        }

        if(other.CompareTag("RedShroom")){
            barVal -= 50;
            barVal = Mathf.Clamp(barVal, 0, 100);
            bar.value = barVal;
            Destroy(other.gameObject);
        }
    }

    public IEnumerator PlayerReborn(string animName){
        GetComponent<Animator>().Play(animName);
        yield return new WaitForSeconds(3.5f);
        subtractVal = true;
    }

    public IEnumerator ResetHealth(){
        subtractVal = false;
        barVal = 100;
        bar.value = barVal;
        yield return new WaitForSeconds(3);
        subtractVal = true;
    }

    // public void DepletetHealth(){
    //     for(int i = 10; i < 0; i--){
    //         SubtractBarVal();
    //     }
    // }
}
