﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject gmObject;
    [SerializeField] GameManager gm;
    private void Start()
    {
        if(gmObject != null)
        {
            gm = gmObject.GetComponent<GameManager>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            gm.currentRespawn = collision.gameObject;
            Debug.Log("Current RespawnPoint" + gm.currentRespawn + "/n" + "Collision Game Object" + collision.gameObject);
            Debug.Log("Saved Respawn Point");
        }
    }
    private void OnDestroy()
    {
        gm.PlayerDied();
    }
}
