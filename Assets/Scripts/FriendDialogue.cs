
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FriendDialogue : MonoBehaviour
{
    public Dialogue dialogueManager;
    public GameObject PlotTwist;
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
            string[] dialogue = { "Charles: Is it really you?",
                                  "Friend: It is.",
                                  "Charles: Did they mess with your head? are you ok?",
                                  "Friend: I am.",
                                  "Charles: Good. That's Good. Come on, we will talk elsewhere. We must go.",
                                  "Friend: I'm afraid you are not going anywhere, friend.",
                                  "Charles: What are you..?"};
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
            PlotTwist.SetActive(true);
        }
    }
   
}
