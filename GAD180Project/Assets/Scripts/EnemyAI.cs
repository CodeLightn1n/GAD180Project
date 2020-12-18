using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    private GameObject Player;
    public PlayerDetection PD;
    public bool MovingLeft;
    Vector2 PlayerPos;
    public float EnemySpeed = 15f;
    Transform EnemyT;
    public Animator anim;
    public Health health;
    public EnemyAttack EA;
    public SceneManager SceneManager;
    private void Start()
    {
        Player = GameObject.Find("Player");
        EnemyT = this.gameObject.transform;
        EA = GetComponent<EnemyAttack>();
    }
    private void Update()
    {
        if(Player == null)
        {
            FindPlayer();
        }
        PlayerPos = Player.gameObject.transform.position;
        if(PD.PlayerCollided)
        {
            TrackPlayer();
        }
        else
        {
            Patrol();
        }
        
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            if (MovingLeft == false)
            {
                MovingLeft = true;
            }
            else
            {
                MovingLeft = false;
            }
        }
    }
    private void Patrol()
    {
        if(MovingLeft == true)
        {
            MoveLeft();
        }
        else
        {
            MoveRight();
        }
    }
    private void MoveLeft()
    {
        EnemyT.Translate(Vector2.left * EnemySpeed * Time.deltaTime);
        this.gameObject.transform.localScale = new Vector2(-5f, 5f);
    }
    private void MoveRight()
    {
        EnemyT.Translate(Vector2.right * EnemySpeed * Time.deltaTime);
        this.gameObject.transform.localScale = new Vector2(5f, 5f);
    }
    IEnumerator BeginDeath()
    {
        EnemySpeed = 0f;
        EA.CanAttack = false;
        if(anim.gameObject.activeSelf)
        {
            Debug.Log("Animator is Active");
        }
        anim.enabled = true;
        anim.SetTrigger("Died");

        if (this.gameObject.name == "RobotBoss")
        {
            SceneManager.LoadScene(0);
        }

        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);

    }
    public void Death()
    {
        StartCoroutine(BeginDeath());
    }
    private void FindPlayer()
    {
        Player = GameObject.Find("Player");
    }
    
}
