﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameObject Player;
    public PlayerDetection PD;
    public bool MovingLeft;
    Vector2 PlayerPos;
    public float EnemySpeed = 15f;
    Transform EnemyT;
    public Animator anim;
    public Health health;
    public EnemyAttack EA;
    private void Start()
    {
        Player = GameObject.Find("Player");
        EnemyT = this.gameObject.transform;
        EA = GetComponent<EnemyAttack>();
    }
    private void Update()
    {
        if(Player == null)
        {
            FindPlayer();
            Debug.Log("Find the player");
        }
        PlayerPos = Player.gameObject.transform.position;
        if(PD.PlayerCollided)
        {
            TrackPlayer();
        }
        else
        {
            Patrol();
        }
    }
    private void TrackPlayer()
    {
        if(PlayerPos.x < this.gameObject.transform.position.x)
        {
            MoveLeft();
        }
        else
        {
            MoveRight();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            if (MovingLeft == false)
            {
                MovingLeft = true;
            }
            else
            {
                MovingLeft = false;
            }
        }
    }
    private void Patrol()
    {
        if(MovingLeft == true)
        {
            MoveLeft();
        }
        else
        {
            MoveRight();
        }
    }
    private void MoveLeft()
    {
        EnemyT.Translate(Vector2.left * EnemySpeed * Time.deltaTime);
    }
    private void MoveRight()
    {
        EnemyT.Translate(Vector2.right * EnemySpeed * Time.deltaTime);
    }
    IEnumerator BeginDeath()
    {
        EnemySpeed = 0f;
        EA.CanAttack = false;
        if(anim.gameObject.activeSelf)
        {
            Debug.Log("Animator is Active");
        }
        anim.enabled = true;
        anim.SetTrigger("Died");
        anim.Play("RobotDeathAnim");
        
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);

    }
    public void Death()
    {
        StartCoroutine(BeginDeath());
    }
    private void FindPlayer()
    {
        Player = GameObject.Find("Player");
    }
}
