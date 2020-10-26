using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameObject Player;
    [SerializeField] GameObject[] PatrolPoints;
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
    private void Patrol()
    {
        foreach(GameObject point in PatrolPoints)
        {
            Vector2 pointX = point.gameObject.transform.position;
            // while(pointX.x != EnemyT.position.x)
            // {
            //     if(pointX.x < EnemyT.position.x)
            //     {
            //         MoveLeft();
            //     }
            //     else if(pointX.x > EnemyT.position.x)
            //     {
            //         MoveRight();
            //     }
            //     else
            //     {
            //         break
            //     }
            // }
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
