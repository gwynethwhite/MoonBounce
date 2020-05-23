using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAstronaut : MonoBehaviour
{
    public Collider2D grounder;
    public Collider2D ceiling;
    private Rigidbody2D rigidBody;
    const float groundedRadius = .2f;
    private bool colliding = false;
    private bool facingRight = true;
    [SerializeField] private float speed;
    [SerializeField] private float xMove;
    [SerializeField] private float yMove;
    [SerializeField] private LayerMask blockLayer;

    private Vector3 lastHit;

    [SerializeField] private Transform groundCheck;


    // Start is called before the first frame update
    void Awake()
    {
        speed = 7;
        xMove = 7;
        yMove = 40;
        lastHit = new Vector3(0,0,0);
        rigidBody = GetComponent<Rigidbody2D>();
    }


    private void HitGroundForce()
    {
        lastHit = transform.position;
        Debug.Log("BAM" + transform.position);
        Vector3 ground = new Vector3(xMove,yMove,0);
        rigidBody.velocity = ground.normalized * speed;
    }

    private void HitWallForce()
    {
        Flip();
        lastHit = transform.position;
        Debug.Log("BONK" + transform.position);
        Vector3 wall = new Vector3(xMove,yMove,0);
        rigidBody.velocity = wall.normalized * speed;
    }

    private void HitItem()
    {
        //Vector3 mySpeed = rigidBody.velocity;
        lastHit = transform.position;
        Debug.Log("BOING" + transform.position);
        Vector3 move = new Vector3(rigidBody.velocity.x * -1f ,rigidBody.velocity.y * -1f ,0);
        rigidBody.velocity = move.normalized * speed;
    }



    void OnCollisionEnter2D(Collision2D collision){

        if (lastHit == transform.position){
          return;
        }

        // collides with BLOCKS
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Blocks")
        {
            // checks if collision is on feet
            if (grounder.IsTouchingLayers(blockLayer))
              {
                  Debug.Log("Hit by Grounder");
                  HitGroundForce();
                  return;
              }
            HitWallForce();
        }

        // collides with GROUND
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Ground")
        {
            HitGroundForce();
        }

        //collides with BOUND
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Bounds")
        {
            HitWallForce();
        }
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Ceiling")
        {
            //HitGroundForce();
        }

        if (LayerMask.LayerToName(collision.gameObject.layer) == "Item")
        {
            //HitWallForce();
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

  		  xMove = xMove * -1f;
  	}


    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
  	{

  	}


}
