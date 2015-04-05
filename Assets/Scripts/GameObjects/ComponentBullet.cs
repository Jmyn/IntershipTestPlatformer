using UnityEngine;
using System.Collections;

public class ComponentBullet : MonoBehaviour
{
    public string owner = "Player";
    private string enemy = "Enemy";
    private float bulletLifeTime = 2f;
	[SerializeField]
	protected int m_dmg = 1;


	void OnTriggerEnter(Collider collision)
	{
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
            OnCollidePlatform();
		}
        
        if (collision.tag == enemy)
        {
            OnCollideEnemy(collision);
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

        GameObject ownerObj = GameObject.Find(owner);
        if(ownerObj != null) {
            ComponentShoot cs =ownerObj.GetComponent<ComponentShoot>();
            if(cs != null) {
                m_dmg = cs.GetBulletDmg();
            }
            Physics.IgnoreCollision(ownerObj.GetComponent<Collider>().collider, GetComponent<Collider>().collider);
            Invoke("Destroy", bulletLifeTime);
        }
    }
        
    void OnDisable()
    {
        CancelInvoke();
    }

    public void SetOwner(string ownerName)
    {
        owner = ownerName;
        enemy = owner == "Player" ? "Enemy" : "Player";
    }
}
