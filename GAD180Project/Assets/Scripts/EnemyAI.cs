using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    Vector2 playerPos;
    [SerializeField] float EnemySpeed = 15f;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        playerPos = player.gameObject.transform.position;
        Movement();
    }
    private void Movement()
    {
        if(playerPos.x < this.gameObject.transform.position.x)
        {
            this.gameObject.transform.Translate(Vector2.left * EnemySpeed * Time.deltaTime);
        }
        else
        {
            this.gameObject.transform.Translate(Vector2.right * EnemySpeed * Time.deltaTime);
        }
    }
}
