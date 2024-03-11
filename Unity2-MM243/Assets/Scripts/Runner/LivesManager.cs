using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour{
    public static int lives = 3;
    public GameObject[] livesUI = new GameObject[lives]; 
    // Start is called before the first frame update
    void Start(){
        print(lives);
    }

    // Update is called once per frame
    void Update(){
        if(lives == 2){
            livesUI[0].SetActive(false);
        }

        if(lives == 1){
            livesUI[0].SetActive(false);
            livesUI[1].SetActive(false);
        }

        if(lives == 0){
            livesUI[0].SetActive(false);
            livesUI[1].SetActive(false);
            livesUI[2].SetActive(false);
            StartCoroutine(RestartGame());
        }
    }

    public IEnumerator RestartGame(){
        yield return new WaitForSeconds(3.5f);
        lives = 3;
        LevelManager.lvlNum = 0;
        SceneManager.LoadScene(0);
    }
}
