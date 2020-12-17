using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject currentRespawn;
    GameObject newPlayer;
    public IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(2);
        newPlayer = Instantiate(playerPrefab, currentRespawn.transform.position, Quaternion.identity);
        newPlayer.name = "Player";
    }
}
