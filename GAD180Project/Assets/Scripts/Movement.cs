using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Inspired by code found at https://sharpcoderblog.com/blog/2d-platformer-character-controller 

    // Move player in 2D space
    public float maxSpeed = 3.4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    public Camera mainCamera;

    bool facingRight = true;
    float moveDirection = 0;
    bool isGrounded = false;
    Vector3 cameraPos;
    Rigidbody2D rb2D;
    Collider2D mainCollider;
    // Check every collider except Player and Ignore Raycast
    LayerMask layerMask = ~(1 << 2 | 1 << 8);
    Transform t;

    // Use this for initialization
    void Start()
    {
        t = transform;
        rb2D = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<Collider2D>();
        rb2D.freezeRotation = true;
        rb2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb2D.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;
        gameObject.layer = 8;

        if (mainCamera)
            cameraPos = mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovementControls();
        Jumping();
        FaceDirection();
    }

    void MovementControls()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
        }
        else if (isGrounded || rb2D.velocity.magnitude < 0.01f)
        {
                moveDirection = 0;
        }
    }

    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpHeight);
        }

        // Camera follow
        if (mainCamera)
            mainCamera.transform.position = new Vector3(t.position.x, cameraPos.y, cameraPos.z);
    }

    void FaceDirection()
    {
        if (moveDirection == 0) return;

        else
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }
    }

    void GroundCheck()
    {
        Bounds colliderBounds = mainCollider.bounds;
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, 0.1f, 0);
        isGrounded = Physics2D.OverlapCircle(groundCheckPos, 0.23f, layerMask);
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, 0.23f, 0), isGrounded ? Color.green : Color.red);
    }
    void FixedUpdate()
    {
        GroundCheck();

        // Apply movement velocity
        rb2D.velocity = new Vector2((moveDirection) * maxSpeed, rb2D.velocity.y);
    }
}