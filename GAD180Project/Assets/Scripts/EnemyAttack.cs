using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    Physics2D circleOfLife;
    Collider2D mainCollider;
    LayerMask layerMask = (8);

    // Start is called before the first frame update
    void Start()
    {
        mainCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Bounds colliderBounds = mainCollider.bounds;
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 2f, 0.1f, 0);
        if (Physics2D.OverlapCircle(groundCheckPos, 0.23f, layerMask))
        {
            Attack();
        }
    }


    void Attack()
    {
        Debug.Log("Beep Boop");
    }
}
