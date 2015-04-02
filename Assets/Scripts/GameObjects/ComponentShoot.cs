using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ComponentShoot : MonoBehaviour
{
	public Rigidbody m_PrefabBullet;
    public Transform gun;
    public int poolSize = 10;
    List<GameObject> bullets;
    private ComponentMovement playerMov;

	[SerializeField]
	protected float m_Speed = 20.0f;

    void Awake()
    {
        // Setting up the references.
        playerMov = transform.root.GetComponent<ComponentMovement>();
    }

    void Start()
    {
    }

	// Update is called once per frame
	void Update ()
	{
		// FIRE!
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody bulletInstance;

            // If the player is facing right...
            if (playerMov.IsFacingRight())
            {
                GameObject bulletObj = ObjectPoolerScript.current.GetPooledObject();
                // ... instantiate the rocket facing right and set it's velocity to the right. 
                bulletInstance = (Rigidbody)bulletObj.GetComponent("Rigidbody");
                bulletInstance.transform.position = gun.transform.position;
                bulletInstance.velocity = new Vector3(m_Speed, 0,0);
                bulletObj.SetActive(true);
                
            }
            else
            {
                GameObject bulletObj = ObjectPoolerScript.current.GetPooledObject();
                // Otherwise instantiate the rocket facing left and set it's velocity to the left.
                bulletInstance = (Rigidbody)bulletObj.GetComponent("Rigidbody");
                //bulletInstance = Instantiate(m_PrefabBullet, gun.transform.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as Rigidbody;
                bulletInstance.transform.position = gun.transform.position;
                bulletInstance.velocity = new Vector3(-m_Speed, 0, 0);
                bulletObj.SetActive(true);
            }
        }

				
	}
    void Shoot()
    {
        Vector3 pos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        Instantiate(m_PrefabBullet,pos,Quaternion.identity);
    }

}
