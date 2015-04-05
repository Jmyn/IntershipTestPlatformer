using UnityEngine;
using System.Collections;

public class DamagePickupScript : MonoBehaviour {
    public int dmgValue = 1; //Bullet damage increase

    private ComponentShoot playerShoot;
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            playerShoot= collision.gameObject.GetComponent<ComponentShoot>();
            Pickup();
        }
    }

    void Pickup()
    {
        UIFloatingText.current.Show(transform.position, "Damage increased!");
        playerShoot.increaseBulletDamage(dmgValue);
        Destroy(gameObject);
    }
}
