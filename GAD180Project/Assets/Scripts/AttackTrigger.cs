using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    
    [SerializeField] GameObject enemyBody;
    [SerializeField] EnemyAttack enemyAttack;

    private void Start()
    {
        enemyAttack = enemyBody.GetComponent<EnemyAttack>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyAttack.Attack();
    }


}
