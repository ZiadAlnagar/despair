﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

	public GameObject CurrentCheckpoint;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void RespawnPlayer()
	{
		FindObjectOfType<Player>().transform.position = CurrentCheckpoint.transform.position;
	}
}