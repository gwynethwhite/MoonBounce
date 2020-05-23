using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is the working auto astronaut script, updated 11:44pm

public class AstroOld : MonoBehaviour
{
    [SerializeField] private float jumpForce = 400f;
    [SerializeField] private float fixedSpeed = 0.5f;

    private Vector3 velocity = new Vector3(0, 0, 0);
    private Rigidbody2D rigidBody;
    const float groundedRadius = .2f;
    const float rightRadius = .2f;
    private bool grounded = false;
    private bool facingRight = true;

    [SerializeField] private Transform groundCheck;							// A position marking where to check if the player is grounded.
  	[SerializeField] private Transform ceilingCheck;							// A position marking where to check for ceilings
    [SerializeField] private Transform rightBound;							// A position marking where to check if the player is grounded.
    [SerializeField] private Transform leftBound;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsWall;


    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision){
        //Debug.Log("Collision");
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Blocks")
        {
            //rigidBody.AddForce(new Vector2(fixedSpeed/2, jumpForce/2));
            if (!grounded)
            {
                Flip();
            }
            else
            {

            }
        }
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Ground")
        {
            rigidBody.AddForce(new Vector2(fixedSpeed / 2, jumpForce / 2));
        }
    }

    public float GetX()
    {
        return transform.position.x;
    }

    public float GetY()
    {
        return transform.position.y;
    }

    private void Flip()
  	{
  		  // Switch the way the player is labelled as facing.
  		  facingRight = !facingRight;

  		  // Multiply the player's x local scale by -1.
  		  Vector3 theScale = transform.localScale;
  		  theScale.x *= -1;
  		  transform.localScale = theScale;

  		  fixedSpeed = fixedSpeed * -1f;
  	}


    // Update is called once per frame
    void Update()
    {
        if (velocity.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (velocity.x < 0 && facingRight)
        {
            Flip();
        }
    }

    void FixedUpdate()
  	{
      /*if (rigidBody.velocity.x == 0)
      {
          rigidBody.AddForce(new Vector2(fixedSpeed/2, jumpForce/2));
      }*/
      //check ground
      bool wasGrounded = grounded;
      grounded = false;
      Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
      //Debug.Log("Checking");
      for (int i = 0; i < colliders.Length; i++)
      {
          Debug.Log(i);
          if (colliders[i].gameObject != gameObject)
          {
              //Debug.Log("DETECTED");
              grounded = true;
              if (!wasGrounded){
                  //Debug.Log("jump");
                  rigidBody.AddForce(new Vector2(fixedSpeed/2, jumpForce/2));
              }
          }
      }

      //add force
      rigidBody.AddForce(new Vector2(fixedSpeed/2, 0));
  	}


}
