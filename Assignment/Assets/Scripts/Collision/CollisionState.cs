﻿using UnityEngine;
using System.Collections;

public class CollisionState : MonoBehaviour
{

    public LayerMask collisionLayer;
    public LayerMask enemyCollisionLayer;
    public bool standing;
    public Vector2 bottomPosition = Vector2.zero;
    public Vector2 rightPosition = Vector2.zero;
    public Vector2 leftPosition = Vector2.zero;
    public float collisionRadius = 50f;
    public Color debugCollisionCollor = Color.red;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        CheckStanding(bottomPosition, collisionLayer);
        //CheckCollisionEnemy(rightPosition, enemyCollisionLayer, false);
        //CheckCollisionEnemy(rightPosition, enemyCollisionLayer, true);
        //CheckCollisionEnemy(leftPosition, enemyCollisionLayer, true);
    }

    void CheckStanding(Vector2 pos, LayerMask layer)
    {
        //Standing
        //var pos = bottomPosition;
        pos.x += transform.position.x;
        pos.y += transform.position.y;
        standing = Physics2D.OverlapCircle(pos, collisionRadius, layer);
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //if (collision.gameObject.tag == "Enemy")
    //    //    collision.gameObject.SendMessage("DIE");
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        if (CheckCollisionEnemy(rightPosition, collision.gameObject.layer))
    //        {
    //            var a = 0;
    //        }
    //        if (CheckCollisionEnemy(leftPosition, collision.gameObject.layer))
    //        {
    //            var a = 0;
    //        }
    //        if (CheckCollisionEnemy(bottomPosition, collision.gameObject.layer))
    //        {
    //            collision.gameObject.SendMessage("DIE");
    //        }
    //    }
    //}

    //public void CheckEnemyCollision(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        if (CheckCollisionEnemy(rightPosition, collision.gameObject.layer))
    //        {

    //        }
    //        else if (CheckCollisionEnemy(leftPosition, collision.gameObject.layer))
    //        {

    //        }
    //        else if (CheckCollisionEnemy(bottomPosition, collision.gameObject.layer))
    //        {
    //            collision.gameObject.SendMessage("DIE");
    //        }
    //    }
    //}

    bool CheckCollisionEnemy(Vector2 positionToCheck, LayerMask layer)
    {
        //Standing
        var pos = positionToCheck;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        return Physics2D.OverlapCircle(pos, collisionRadius, layer);
        //if(!sides) collision.gameObject.SendMessage("DIE");
    }


    void OnDrawGizmos()
    {
        Gizmos.color = debugCollisionCollor;

        var pos = bottomPosition;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        Gizmos.DrawWireSphere(pos, collisionRadius);

        pos = leftPosition;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        Gizmos.DrawWireSphere(pos, collisionRadius);

        pos = rightPosition;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        Gizmos.DrawWireSphere(pos, collisionRadius);
    }
}
