﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    // Use this for initialization

    private SpriteRenderer sr;
    public Sprite explodedBlock;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && other.GetContact(0).point.y < transform.position.y)
        {
            sr.sprite = explodedBlock;
            Object.Destroy(gameObject, .2f);
        }
    }
}
