﻿using UnityEngine;
using System.Collections;

public class Jump : AbstractBehavoir {

    public float jumpSpeed = 200f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var canJump = inputState.GetButtonValue(inputButtons[0]);
        var holdTime = inputState.GetButtonHoldTime(inputButtons[0]);


        if (collisionState.standing)
        {
            if (canJump && holdTime < .1f)
            {
                OnJump();
            }
        }
	}

    public void OnJump()
    {
        var vel = body2d.velocity;

        body2d.velocity = new Vector2(vel.x, jumpSpeed);
    }
}
