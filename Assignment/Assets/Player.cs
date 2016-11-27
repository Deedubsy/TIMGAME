﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField]
    private float m_MaxSpeed = 30f;                    // The fastest the player can travel in the x axis.
    [SerializeField]
    private float m_JumpForce = 400f;


    private Rigidbody2D m_Rigidbody2D;

    // Use this for initialization
    void Start () {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.freezeRotation = true;
    }
	
	// Update is called once per frame
	void Update () {
        //LEFT
        if (Input.GetKey(KeyCode.A))
        {
            m_Rigidbody2D.velocity = new Vector2((-m_MaxSpeed * Time.deltaTime) * m_MaxSpeed, m_Rigidbody2D.velocity.y);
        }

        //LEFT
        if (Input.GetKey(KeyCode.D))
        {
            m_Rigidbody2D.velocity = new Vector2((m_MaxSpeed * Time.deltaTime) * m_MaxSpeed, m_Rigidbody2D.velocity.y);
        }

        //LEFT
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Rigidbody2D.AddForce(new Vector2((m_MaxSpeed * Time.deltaTime) * m_MaxSpeed, m_JumpForce));
        }
    }
}