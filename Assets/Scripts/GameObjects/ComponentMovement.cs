using UnityEngine;
using System.Collections;

public class ComponentMovement : MonoBehaviour 
{
    public Rigidbody rb;
    public bool facingRight = true;
    public float maxSpeed = 10f;
    public float moveForce = 100f;
    public bool doubleJump = false;
    public bool jump = false;
    private Transform groundCheck;			// A position marking where to check if the player is grounded.
    public bool grounded = false;			// Whether or not the player is grounded.

	//TODO movement
	float m_speed = 0.1f;
	[SerializeField]
	protected float m_jumpHeight = 11;

	// Use this for initialization
	void Start () 
	{
        
	}

    void Awake()
    {
        // Setting up references.
        groundCheck = transform.Find("/"+name +"/groundCheck");
    }

    void Update()
    {
        // The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
        grounded = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (grounded) { 
            doubleJump = false;
        }
        

        if ((grounded || !doubleJump) && Input.GetButtonDown("Jump"))
        {
            jump = true;

            if (!doubleJump && !grounded)
            {
                jump = true;
                doubleJump = true;
            }
        }

    }
	
	// Update is called once per frame
    void FixedUpdate()
    {
        
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");
        

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
        if (h * rb.velocity.x < maxSpeed) { 
			rb.AddForce(Vector3.right * h * moveForce);
        }
		// If the player's horizontal velocity is greater than the maxSpeed...
        if (Mathf.Abs(rb.velocity.x) > maxSpeed) { 
			// ... set the player's velocity to the maxSpeed in the x axis.
			rb.velocity = new Vector3(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y, 0);
        }

        // If the input is moving the player right and the player is facing left...
        if (h > 0 && !facingRight)
        {
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (h < 0 && facingRight)
        {
            //flip the player.
            Flip();
        }
		
        if (jump)
        {
            //rb.AddForce(transform.up * m_jumpHeight,ForceMode.VelocityChange);

            
            rb.velocity = new Vector3(rb.velocity.x, 0f,0f);
            // Add a vertical force to the player.
            rb.AddForce(new Vector3(0f, m_jumpHeight, 0f), ForceMode.VelocityChange);

            // Make sure the player can't jump again until the jump conditions from Update are satisfied.
             jump = false;
        }  
      
    }

    public bool IsFacingRight() { return facingRight; }
    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
	
	

}
