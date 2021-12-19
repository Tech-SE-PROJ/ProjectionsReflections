using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using Random = System.Random;
using System.Timers;

public class EnemyMovement3 : MonoBehaviour
{
    public float movementSpeed = 10.5f;
    public GameObject player;
    public Rigidbody2D eRB;
    private Rigidbody2D pRB;
    public Vector2 playerPosition, enemyPosition, movement;
    public double theta;
    public float savedTime = 5;
    private System.Timers.Timer aTimer;


    void SetTimer()
    {
        aTimer = new System.Timers.Timer(900);
        aTimer.Elapsed += OnTimedEvent;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
    }

    private void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        Random rand = new Random((int)enemyPosition.x * (int)enemyPosition.y);
        theta = rand.NextDouble() * 6.28;
        //theta = pRB.rotation + 3.14f;



        movement = new Vector2((float)(Math.Sin(theta) * movementSpeed), (float)(Math.Cos(theta) * movementSpeed));
    }

    void Start()
    {
        pRB = player.GetComponent<Rigidbody2D>();
        SetTimer();
    }

    void Update()
    {
        if (!player)
        {
            return;
        }
        playerPosition = pRB.position;
        enemyPosition = eRB.position;
    }

    void FixedUpdate()
    {
        if ((Vector2.Distance(enemyPosition, playerPosition) > .5))
        {
            eRB.MovePosition(eRB.position + movement * movementSpeed * Time.fixedDeltaTime);
        }
    }
}
