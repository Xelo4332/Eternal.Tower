using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryElement : MonoBehaviour
{
    public Dialogue dialogue;

    //Startar TriggerDialogue metoden
    private void Start()
    {
        TriggerDialogue();
    }

    //vi skapar metoden så vi kan använda startdialogue här och i dialogue manager
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }



}
