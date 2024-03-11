using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour{
    public Slider bar;
    public int barVal = 100;
    [SerializeField] int subVal = 10;
     public bool subtractVal = true;
    // Start is called before the first frame update
    void Start(){
        //barVal = 100;
        bar.value = barVal;
        InvokeRepeating(nameof(SubtractBarVal), 3, 3);
    }

    // Update is called once per frame
    void Update(){
        if(barVal == 0){
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

    public IEnumerator PlayerReborn(string animName){
        subtractVal = false;
        GetComponent<Animator>().Play(animName);
        yield return new WaitForSeconds(3.5f);
        ResetHealth();
        subtractVal = true;
    }

    public void ResetHealth(){
        barVal = 100;
        bar.value = barVal;
    }

    public void DepletetHealth(){
        for(int i = 10; i < 0; i--){
            SubtractBarVal();
        }
    }
}
