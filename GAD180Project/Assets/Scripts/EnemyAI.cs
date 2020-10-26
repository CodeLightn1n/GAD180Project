using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameObject Player;
    public bool MovingLeft;
    Vector2 PlayerPos;
    [SerializeField] float EnemySpeed = 15f;
    Transform EnemyT;
    private void Start()
    {
        Player = GameObject.Find("Player");
        EnemyT = this.gameObject.transform;
    }
    private void Update()
    {
        PlayerPos = Player.gameObject.transform.position;
        Patrol();
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
    
}
