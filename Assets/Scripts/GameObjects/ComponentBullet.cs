using UnityEngine;
using System.Collections;

public class ComponentBullet : MonoBehaviour
{
	[SerializeField]
	protected int m_dmg = 1;


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
		Destroy ();
	}

    public void OnCollideEnemy(Collider collider)
    {
        ComponentHealth enemyHp = collider.gameObject.GetComponent<ComponentHealth>();
        if (enemyHp != null)
        {
            enemyHp.Modify(-m_dmg);
        }
        Destroy();
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        Invoke("Destroy",2f);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
