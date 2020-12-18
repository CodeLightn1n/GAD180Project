using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject currentRespawn;
    GameObject newPlayer;
    public Text WinText;
    
    private void Start()
    {
        WinText.GetComponent<Text>();
        WinText.gameObject.SetActive(false);
    }
    public IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(2);
        newPlayer = Instantiate(playerPrefab, currentRespawn.transform.position, Quaternion.identity);
        newPlayer.name = "Player";
    }

}
