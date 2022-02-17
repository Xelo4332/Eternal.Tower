using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Sherzad

public class DialogueManager : MonoBehaviour
{
    //Variabler f�r Name och dialogue text
    public Text nameText;
    public Text dialogueText;

   // Med hj�lp av Queue vi kan anv�nda string som sentences
    private Queue<string> sentences;

    //
    void Start()
    {
        sentences = new Queue<string>();
        
    }

    //Startar dialogue med att texten skrivs om med hj�lp av DisplayNext vi kan byta string. Om det finns inga sentences d� 
    //Avslutar den dialogue
    public void StartDialogue(Dialogue dialogue)
    {

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    //Med h�lp av coroutine vi kan displaya mer sentences
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //Den h�r metoden g�r att man dator skriver text f�r oss
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    //avslutar dialogue
    void EndDialogue()
    {
        Debug.Log("End of conversation");
    }

}
