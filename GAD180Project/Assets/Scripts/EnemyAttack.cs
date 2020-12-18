using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform AttackPointT;
    [SerializeField] LayerMask PlayerLayer;
    Animation RobotLaserAttack;
    float AttackRange = 0.75f;
    public bool CanAttack;
    public Animator anim;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && CanAttack)
        {
            StartCoroutine(DelayAttack());
        }
    }
    public void Attack()
    {
        if(this.gameObject != null)
        {
            anim.SetTrigger("Attacked");
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(AttackPointT.position, AttackRange, PlayerLayer);

            foreach (Collider2D player in hitPlayer)
            {
                Debug.Log("Smacked " + player.name);
                player.GetComponent<Health>().GetHit();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPointT== null) return;

        Gizmos.DrawSphere(AttackPointT.position, AttackRange);
    }
    IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(2);
        Attack();
    }
    IEnumerator onDeath()
    {
        anim.SetTrigger("Died");
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
    public void Death()
    {
        StartCoroutine(onDeath());
    }
}
