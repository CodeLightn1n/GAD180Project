using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerPrefab;
    public GameObject currentRespawn;
    private void Start()
    {

    }
    public void PlayerDied()
    {
        Instantiate(playerPrefab, currentRespawn.transform.position, Quaternion.identity);
    }
}
