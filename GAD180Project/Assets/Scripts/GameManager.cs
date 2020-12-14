using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject currentRespawn;
    GameObject newPlayer;
    private void Start()
    {

    }
    public void PlayerDied()
    {
        newPlayer = Instantiate(playerPrefab, currentRespawn.transform.position, Quaternion.identity);
        newPlayer.name = "Player";
    }
}
