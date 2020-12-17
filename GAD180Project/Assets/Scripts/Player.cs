using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject gmObject;
    public GameManager gm;
    public Animator anim;
    public Movement2 move;
    private void Start()
    {
        gmObject = GameObject.Find("GameManager");
        move = GetComponent<Movement2>();
        if(gmObject != null)
        {
            gm = gmObject.GetComponent<GameManager>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with : " + collision.name);
        if (collision.gameObject.layer == 11)
        {
            gm.currentRespawn = collision.gameObject;
            Debug.Log("Current RespawnPoint" + gm.currentRespawn + "/n" + "Collision Game Object" + collision.gameObject);
            Debug.Log("Saved Respawn Point");
        }
    }
    public void Death()
    {
        
        StartCoroutine(BeginDeath());
        StartCoroutine(gm.RespawnPlayer());
    }
    IEnumerator BeginDeath()
    {
        
        this.gameObject.layer = 10;
        move.maxSpeed = 0f;

        if(!anim.gameObject.activeSelf)
        {
            anim.enabled = true;
        }
        
        anim.SetTrigger("HasDied");
        anim.Play("PlayerDeathAnim");
        
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);       
    }
}
