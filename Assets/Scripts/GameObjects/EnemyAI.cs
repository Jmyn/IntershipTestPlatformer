using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
    private Transform groundCheck;
    private Transform frontCheck;
    private ComponentShoot cs;

    private Transform target;
    public float range = 20f; 
    public float moveForce = 2f;
    public float maxSpeed = 10f;
    public bool facingRight = true;
    public bool onEdge = false;			// Whether or not the enemy is onEdge.
	// Use this for initialization
	void Awake () {
        frontCheck = transform.Find("frontCheck");
        groundCheck = transform.Find("/" + name + "/groundCheck");
        cs = GetComponent<ComponentShoot>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        Collider[] frontHits = Physics.OverlapSphere(frontCheck.position, 1);

        // Check each of the colliders in front
        foreach (Collider c in frontHits)
        {
            // If any of the colliders is an Obstacle...
            if (c.tag == "Obstacle" || c.tag == "Enemy")
            {
                // ... Flip the enemy and stop checking the other colliders.
                Flip();
                break;
            }
        }
        onEdge = !Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if(onEdge) {
            Flip();
        }
        if (target != null)
        {
            var vect = (target.transform.position - transform.position);
            if (vect.magnitude < range)
            {
                cs.FireBullet(vect.normalized);
            }
        } 
        
	}



    void FixedUpdate()
    {
        if(facingRight ) {
            rigidbody.AddForce(Vector3.right  * moveForce,ForceMode.VelocityChange);
        }
        else
        {
            rigidbody.AddForce(Vector3.left * moveForce, ForceMode.VelocityChange);
        }
        if (Mathf.Abs(rigidbody.velocity.x) > maxSpeed)
        {
            // ... set the player's velocity to the maxSpeed in the x axis.
            rigidbody.velocity = new Vector3(Mathf.Sign(rigidbody.velocity.x) * maxSpeed, rigidbody.velocity.y, 0);
        }
       
    }

    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void setSpeed(float spd)
    {
        maxSpeed = spd;
    }
}
