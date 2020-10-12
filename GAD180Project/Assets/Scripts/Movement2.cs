using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    Rigidbody2D rg2d;
    Vector2 movementForce;
    [SerializeField] float maxSpeed;
    private void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        movementForce = new Vector2(1f, 0f);
        maxSpeed = 25f;
    }
    private void FixedUpdate()
    {
        //Move Right
        if(Input.GetKey(KeyCode.D))
        {
            rg2d.AddForce(movementForce, ForceMode2D.Impulse);
        }
        //Move Left
        if(Input.GetKey(KeyCode.A))
        {
            rg2d.AddForce(-movementForce, ForceMode2D.Impulse);
        }
        if(rg2d.velocity.magnitude > maxSpeed)
        {
            rg2d.velocity += rg2d.velocity.normalized * maxSpeed;
        }
    }
}
