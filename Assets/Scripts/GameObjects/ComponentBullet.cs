using UnityEngine;
using System.Collections;

public class ComponentBullet : MonoBehaviour
{
	[SerializeField]
	protected int m_dmg = 1;

	void Start()
	{
        Destroy(gameObject, 2f);
	}
	// Update is called once per frame
	void Update ()
	{
	}

	void OnTriggerEnter(Collider collider)
	{
        Debug.Log("COLLIDE");
		if (collider.tag == "Ground")
		{
            OnCollidePlatform();
		}
        if(collider.tag =="Enemy") {
            OnCollideEnemy(collider);
        }
        
	}

    public void OnCollidePlatform()
	{
		Destroy (gameObject);
	}

    public void OnCollideEnemy(Collider collider)
    {
        ComponentHealth enemyHp = collider.gameObject.GetComponent<ComponentHealth>();
        if (enemyHp != null)
        {
            enemyHp.Modify(-m_dmg);
        }
        Destroy(gameObject);
    }
}
