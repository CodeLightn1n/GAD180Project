using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject player;
    public GameObject currentRespawn;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    public void PlayerDied()
    {
        Instantiate(player.gameObject, currentRespawn.transform.position, Quaternion.identity);
    }
}
