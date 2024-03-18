using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour{
    public static int lives = 3;
    public GameObject[] livesUI = new GameObject[lives]; 
    public GameObject screenFade;
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
        screenFade.SetActive(true);
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(1.7f);
        screenFade.SetActive(false);
    }
}
