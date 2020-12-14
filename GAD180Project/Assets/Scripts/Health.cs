using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int HP;
    public bool Dead;
    public UnityEvent onDeath;
    public void Start()
    {
        HP = 1;
        Dead = false;
    }
    public void GetHit()
    {
        HP--;
        if(HP <= 0)
        {
            Dead = true;
            Die();
        }
    }
    public void Die()
    {
        onDeath.Invoke();
    }
}
