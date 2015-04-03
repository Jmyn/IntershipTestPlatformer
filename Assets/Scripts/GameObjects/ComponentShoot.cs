using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(ComponentCooldown))]
public class ComponentShoot : MonoBehaviour
{
	public Rigidbody m_PrefabBullet;
    private bool onCooldown = false;
    private ComponentCooldown cd;
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
        if (Input.GetButtonDown("Fire1") && !onCooldown)
        {
            Rigidbody bulletInstance;
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -Camera.main.transform.position.z; // distance from the camera
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            GameObject bulletObj = ObjectPoolerScript.current.GetPooledObject();
            ComponentBullet cbullet = bulletObj.GetComponent<ComponentBullet>();
            cbullet.SetOwner(tag);
            Vector3 bulletDirection = mousePosition-transform.position;
         
            bulletInstance = (Rigidbody)bulletObj.GetComponent("Rigidbody");
            bulletInstance.transform.position = transform.position;
            bulletInstance.velocity = (bulletDirection).normalized * m_Speed;
            bulletObj.SetActive(true);
            SetCooldown(true);
            cd.StartCooldown();
     
        }

				
	}

    public void SetCooldown(bool cd)
    {
        onCooldown = cd;
    }

}
