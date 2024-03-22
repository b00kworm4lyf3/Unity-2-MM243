using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    //[SerializeField] Dialogue dialogue;

    // public bool isNPC;
    // public string playerName;

    public float textDisplaySpeed = 1f;

    public Animator animator;
    public GameObject dialoguePanel;
    public AudioSource dialogueSound;
    //public GameObject portal;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue){

        //dialoguePanel.SetActive(true);
        animator.SetBool("BoxOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        //Matt mod for duel dialogue
        
        // if(isNPC == false)
        // {
        //     nameText.text = playerName;
        // }
        // isNPC = !isNPC;
        // if(isNPC == true)
        // {
        //     nameText.text = name;
        // }
        
        //end Matt mod for duel dialogue
        string sentence = sentences.Dequeue();
        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        dialogueSound.Play();
        yield return new WaitForSeconds(0.3f);
        foreach(char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(textDisplaySpeed);
        }
        yield return new WaitForSeconds(0.5f);
        DisplayNextSentence();
    }

    public void EndDialogue(){
        animator.SetBool("BoxOpen", false);
        //yield return new WaitForSeconds(1f);
        //dialoguePanel.SetActive(false);
    }
}
