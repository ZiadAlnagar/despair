using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructionsDialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueManager;
    public GameObject instructionsTrigger;

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
            instructionsTrigger.SetActive(false);
            string[] dialogue = { "Guide: Your friend has been kidnapped! you must save him.",
                                  "Guide: Navigate through the towns to find the Golden Key.",
                                  "Guide: You need the key to unlock the Gate and save your friend.",
                                  "Guide: Jump using W, Move left and Right using A and D",
                                  "Guide: Fireball: F. Barrier: Q. Heal: R."};
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }

}

