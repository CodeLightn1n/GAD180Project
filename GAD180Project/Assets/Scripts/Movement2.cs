using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    Rigidbody2D rg2d;
    Vector2 movementForce;
    public float maxSpeed;
    public float jumpHeight;
    bool grounded;
    
    private void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        movementForce = new Vector2(1f, 0f);
        maxSpeed = 25f;
        jumpHeight = 17f;
        grounded = true;
    }
    
    private void Movement()
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
    }
    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.W) && grounded == true)
        {
            grounded = false;
            rg2d.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
        if(rg2d.velocity.y == 0)
        {
            grounded = true;
        }

    }
    private void FixedUpdate()
    {
        Movement();
        
    }

    private void Update()
    {
        Jump();
    }
}
