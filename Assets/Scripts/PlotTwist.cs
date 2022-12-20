using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotTwist : MonoBehaviour
{
    public GameObject Friend;
    public GameObject Wizard;
    private float DeathAfter = 0f;
    private float DeathDuration = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Friend.SetActive(false);
        Wizard.SetActive(true);
    }
    
    }

