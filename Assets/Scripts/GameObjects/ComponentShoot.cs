using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(ComponentCooldown))]
public class ComponentShoot : MonoBehaviour
{
    private bool onCooldown = false;
    private ComponentCooldown cd;

    [SerializeField]
    protected int m_dmg = 1;
	[SerializeField]
	protected float m_Speed = 20.0f;

    void Awake()
    {
        cd = GetComponent<ComponentCooldown>();
    }
	// Update is called once per frame
	void FixedUpdate ()
	{
		// FIRE!
        if (Input.GetButtonDown("Fire1") && tag == "Player")
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -Camera.main.transform.position.z; // distance from the camera
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 bulletDirection = mousePosition-transform.position;

            FireBullet(bulletDirection);
            
     
        }

				
	}

    public void FireBullet(Vector3 direction)
    {
        if(!onCooldown ) {
            Rigidbody bulletRb;
            GameObject bulletObj = ObjectPoolerScript.current.GetPooledObject();
            if(bulletObj != null) {
                ComponentBullet cbullet = bulletObj.GetComponent<ComponentBullet>();
                cbullet.SetOwner(name);
                bulletRb = (Rigidbody)bulletObj.GetComponent("Rigidbody");
                bulletRb.transform.position = transform.position;
                bulletRb.velocity = (direction).normalized * m_Speed;
                bulletObj.SetActive(true);
                SetCooldown(true);
                cd.StartCooldown();
            }
        }
    }

    public void SetCooldown(bool cd)
    {
        onCooldown = cd;
    }

    public void IncreaseBulletSpeed(float amt) {
        m_Speed += amt;
    }

    public void increaseBulletDamage(int amt)
    {
        m_dmg += amt;
    }

    public int GetBulletDmg() { return m_dmg; }
}
