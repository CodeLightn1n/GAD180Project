using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public bool PlayerCollided;
    private void Start()
    {
        PlayerCollided = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            PlayerCollided = true;
            //Debug.Log("Player collided");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            PlayerCollided = false;
            //Debug.Log("Player has uncollided");
        }
    }
}
