using UnityEngine;

public class SoundOnTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
