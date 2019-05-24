using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerState))]
public class PlayerJump : MonoBehaviour
{
    //player capability configuration 
    [SerializeField]
    private float jumpForce = 820f;

    //cache
    private PlayerMove playerMove;
    private PhysicalObject physicalObject;

    private new Rigidbody2D rigidbody;


    //player state
    private bool startingJump = false;

    // Start is called before the first frame update
    void Start()
    {

        playerMove = GetComponent<PlayerMove>();
        physicalObject = GetComponent<PhysicalObject>();
        rigidbody = physicalObject.body.GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && playerMove.GetComponent<PlayerState>().Grounded)
        {
            startingJump = true;
            physicalObject.animator.SetBool("IsJumping", true);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (startingJump)
            Jump();
     
    }

    void Jump()
    {
        Vector2 playervelocity = rigidbody.velocity;
        playervelocity.y = 0f;
        rigidbody.velocity = playervelocity;
        rigidbody.AddForce(new Vector2(0f, jumpForce));
        rigidbody.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        startingJump = false;
    }
}
