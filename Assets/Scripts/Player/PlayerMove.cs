using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicalObject))]
public class PlayerMove : MonoBehaviour
{
 
    //player state
    public bool IsLookingRight = true;

    //cache
    private PlayerState playerState;
    private PhysicalObject physicalObject;
    private GameObject body
    {
        get
        {
            return physicalObject.body;
        }
    }
    private new Rigidbody2D rigidbody;



    //cache of 'tunable' components

    void Start()
    {
        physicalObject = GetComponent<PhysicalObject>();
        PhysicalObject physicalObject2 = GetComponent<PhysicalObject>();
        playerState = GetComponent<PlayerState>();
        rigidbody = body.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    { 
        FreezeXAxisOnRamp();
        Move();
    }

    void Move()
    {
        float horizontalInput = 0f;

        horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput != 0)
        {
            rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.None;
        }
        rigidbody.AddForce(Vector2.right * horizontalInput * physicalObject.HorizontalAcceleration * Time.fixedDeltaTime);

        if (Mathf.Abs(rigidbody.velocity.x) > physicalObject.MaxHorizontalSpeed * Time.fixedDeltaTime)
        {
            float newHorizontalVelocity = physicalObject.MaxHorizontalSpeed * Mathf.Sign(rigidbody.velocity.x) * Time.fixedDeltaTime;
            rigidbody.velocity = new Vector2(newHorizontalVelocity, rigidbody.velocity.y);
        }

        physicalObject.animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        if (horizontalInput > 0 && !IsLookingRight)
            Flip();
        else if (horizontalInput < 0 && IsLookingRight)
            Flip();
    }
    void Flip()
    {
        IsLookingRight = !IsLookingRight;
        body.transform.localScale = new Vector3(-1 * body.transform.localScale.x, body.transform.localScale.y);
        if (playerState.Grounded)
        {
            Vector2 playerVelocity = rigidbody.velocity;
            playerVelocity.x = 0f;
            rigidbody.velocity = playerVelocity;
        }
    }

    void FreezeXAxisOnRamp()
    {
        if (playerState.Grounded)
        {
            rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        }
    }
}
