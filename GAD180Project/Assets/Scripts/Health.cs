using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int HP;
    public bool Dead;
    public UnityEvent Death;
    public void Start()
    {
        Dead = false;
        HP = 1;
    }
    public void GetHit()
    {
        HP--;
        if(HP <= 0)
        {
            Dead = true;
            Death.Invoke();
        }
    }

}
