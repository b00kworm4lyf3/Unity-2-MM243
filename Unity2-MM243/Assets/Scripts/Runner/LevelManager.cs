using System.Collections;
using UnityEngine;
using StarterAssets;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour{
    Vector3 startPos;
    Quaternion startRot;
    public static int lvlNum = 0;
    [SerializeField] int numLvls = 3;
    [SerializeField] GameObject shockwave;
    [SerializeField] HealthManager healthManager;
    public GameObject screenFade;
    public AudioSource audioSource;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start(){
        screenFade.SetActive(false);
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
            Instantiate(shockwave, other.transform.position, other.transform.rotation);
            //other.gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject, 0.2f);
        }

        else if(other.CompareTag("Goal")){
            startPos = other.transform.position;
            startRot = other.transform.rotation;
            Instantiate(shockwave, other.transform.position, other.transform.rotation);
            //other.gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject, 0.2f);
            StartCoroutine(Goal());

            if(lvlNum == 1){
                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }
    }

    IEnumerator Respawn(){
        LivesManager.lives--;
        DisableController();
        screenFade.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        transform.SetPositionAndRotation(startPos, startRot);
        yield return new WaitForSeconds(1.5f);
        screenFade.SetActive(false);
        GetComponent<Animator>().Play("LOSE00");
        StartCoroutine(healthManager.ResetHealth());
        yield return new WaitForSeconds(3.283f);

        EnableController();
    }

    IEnumerator Goal(){
        healthManager.subtractVal = false;
        DisableController();
        yield return new WaitForSeconds(0.2f);
        
        GetComponent<Animator>().Play("WIN00");

        yield return new WaitForSeconds(3.4f);
        EnableController();

        NextLvl();
    }

    void DisableController(){
        GetComponent<CharacterController>().enabled = false;
        GetComponent<ThirdPersonController>().enabled = false;
    }

    void EnableController(){
        GetComponent<ThirdPersonController>().enabled = true;
        GetComponent<CharacterController>().enabled = true;
    }

    void NextLvl(){
        lvlNum++;

        if(lvlNum > numLvls){
            lvlNum = 0;
        }

        healthManager.subtractVal = true;
        SceneManager.LoadScene(lvlNum);
    }
}
