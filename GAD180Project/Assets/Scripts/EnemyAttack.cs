using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform AttackPointT;
    [SerializeField] LayerMask PlayerLayer;
    float AttackRange = 0.75f;
    public bool CanAttack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(DelayAttack());
        }
    }
    public void Attack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(AttackPointT.position, AttackRange, PlayerLayer);

        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<Health>().GetHit();
            Debug.Log("Smacked " + player.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPointT== null) return;

        Gizmos.DrawSphere(AttackPointT.position, AttackRange);
    }
    IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(100f);
        if(CanAttack)
        {
            Attack();
        }
    }
}
