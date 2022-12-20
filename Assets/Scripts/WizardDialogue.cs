
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WizardDialogue : MonoBehaviour
{
    public Dialogue dialogueManager;
    public GameObject PlotTwist;
    public GameObject Despair;
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
            string[] dialogue = { "Charles: Who are you?",
                                  "Ancient One: You know who I am.",
                                  "Charles: What did you do to my friend? Give him back.",
                                  "Ancient One: I am right here. Come on, Charles... Use your head. Think.",
                                  "Charles: When did you replace him?",
                                  "Ancient One: When you were very little.",
                                  "Charles: But... why? You knew where the Key was. You also knew where the gate was.",
                                  "Charles: Why me? Why didn't you do all of this on your own?",
                                  "Ancient One: I'm afraid my time is short, friend. Goodbye."};

            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
            PlotTwist.SetActive(false);
            Despair.SetActive(true);
        }
    }
   
}
