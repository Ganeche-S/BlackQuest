﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
	public Vector2 newMinPos;
    public Vector2 newMaxPos;
    public Vector3 movePlayer;
	private CameraMovement cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {
    	if(other.CompareTag("Player")) {
    		cam.minPosition = newMinPos;
    		cam.maxPosition = newMaxPos;
            other.transform.position += movePlayer;
    	}
    }
}
