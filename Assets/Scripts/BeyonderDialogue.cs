
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BeyonderDialogue : MonoBehaviour
{
    public Dialogue dialogueManager;
    public GameObject beyonderDialogue;

    // Use this for initialization
    void Start()
    {
       
    }
    
    // Update is called once per frame
    void Update()
    {
       
             
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            beyonderDialogue.SetActive(false);
            string[] dialogue = { "Beyonder: I see you have arrived.",
                                  "Charles: You do not look surprised.",
                                  "Beyonder: There is nothing for you here. Go back.",
                                  "Charles: Sure, after you give me my friend back.",
                                  "Beyonder: You've been warned. "};
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
   
}
