using UnityEngine;
using System.Collections;

public class HastePickup : MonoBehaviour {

    public float buffMult = 1.1f;
    private ComponentMovement playerMov;
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            playerMov = collision.gameObject.GetComponent<ComponentMovement>();
            Pickup();
        }
    }

    //Save the original cooldown, teleport pickup to somewhere not visible and start the timer.
    void Pickup()
    {
        UIFloatingText.current.Show(transform.position, "Speed increased!");
        playerMov.SetJumpHeight(playerMov.GetJumpHeight() * buffMult);
        playerMov.SetMaxSpeed(playerMov.GetMaxSpeed() * buffMult);
        Destroy(gameObject);
    }

}
