using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    [SerializeField] Transform attackPoint;
    [SerializeField]LayerMask enemyLayer;
    float attackRange = 0.75f;
    Rigidbody2D rb2d;
    Vector2 movementForce;
    Camera cam;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movementForce = new Vector2(15f, 0f);
        cam = Camera.main;
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
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().GetHit();
            Debug.Log("Smacked " + enemy.name);
        }
    }

    void DashAttack()
    {

    }

private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
