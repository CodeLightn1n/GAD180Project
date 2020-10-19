using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    Rigidbody2D rg2d;
    Vector2 movementForce;
    [SerializeField] float maxSpeed;
    [SerializeField] float jumpHeight;
    [SerializeField] bool grounded;
    
    private void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        movementForce = new Vector2(1f, 0f);
        maxSpeed = 25f;
        jumpHeight = 17f;
        grounded = true;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Platform")
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
    private void movement()
    {
        //Move Right
        if (Input.GetKey(KeyCode.D))
        {
            rg2d.AddForce(movementForce, ForceMode2D.Impulse);
            this.gameObject.transform.localScale = new Vector2(1.5f, 1.5f);
        }
        //Move Left
        if (Input.GetKey(KeyCode.A))
        {
            rg2d.AddForce(-movementForce, ForceMode2D.Impulse);
            this.gameObject.transform.localScale = new Vector2(-1.5f, 1.5f);
        }
        //Max Speed default is 25
        if (rg2d.velocity.magnitude > maxSpeed)
        {
            rg2d.velocity += rg2d.velocity.normalized * maxSpeed;
        }
        if(grounded)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rg2d.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            }
        }
    }
    private void FixedUpdate()
    {
        movement();
    }
}
