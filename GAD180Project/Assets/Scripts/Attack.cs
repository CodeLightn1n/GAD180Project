using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    [SerializeField] Transform attackPoint;
    [SerializeField]LayerMask enemyLayer;
    float attackRange = 0.75f;
    Collider2D[] hitEnemies;
    Rigidbody2D rb2d;
    Vector2 movementForce;
    Camera cam;
    Vector2 Direction;
    Transform PlayerT;
    public float DashDistance;
    public Health health;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movementForce = new Vector2(15f, 0f);
        cam = Camera.main;
        PlayerT = this.gameObject.transform;
        DashDistance = 10f;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            BasicAttack();
        }
        if(Input.GetMouseButtonDown(0))
        {
            DashAttack();
        }
    }

    void BasicAttack()
    {
        hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().GetHit();
            Debug.Log("Smacked " + enemy.name);
        }
    }

    void DashAttack()
    {
        Debug.Log("Dash Attack");
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        Direction = new Vector2(x, y);
        Vector3 rayCastOffSet = new Vector3(PlayerT.localScale.x, 0f, 0f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + rayCastOffSet, Direction, DashDistance);
        if (hit.collider != null && hit.collider.gameObject.tag == "Enemy")
        {
            Debug.Log("You hit the enemy");
            health = hit.collider.gameObject.GetComponent<Health>();
            health.GetHit();
            Debug.Log(hit.collider.gameObject.name);
        }
        Debug.DrawRay(transform.position + rayCastOffSet, Direction * DashDistance, Color.green, 5f);
        this.gameObject.transform.Translate(Direction * DashDistance);
        
    }

private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
