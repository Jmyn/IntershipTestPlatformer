using UnityEngine;
using System.Collections;

public class CooldownPickupScript : MonoBehaviour {
    public float cdValue = 0.1f; //Cooldown decrease
    public int speedValue = 5; //Bullet speed increase

    private ComponentShoot playerShoot;
    private ComponentCooldown playerCd;
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            playerCd = collision.gameObject.GetComponent<ComponentCooldown>();
            playerShoot = collision.gameObject.GetComponent<ComponentShoot>();
            Pickup();
        }
    }

    void Pickup() 
    {
        UIFloatingText.current.Show(transform.position, "Cooldown decreased!");
        playerCd.SetCooldownTime(playerCd.m_cooldownTimer - cdValue);
        playerShoot.IncreaseBulletSpeed(speedValue);
        Destroy(gameObject);
    }

}
