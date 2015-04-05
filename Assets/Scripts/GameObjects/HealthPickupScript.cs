using UnityEngine;
using System.Collections;

public class HealthPickupScript : MonoBehaviour {
    public int hpValue = 3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(15,30,45)* Time.deltaTime);
	}

    void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player") {
            UIFloatingText.current.Show(transform.position, "MaxHp increased!");
            ComponentHealth playerHp = collision.gameObject.GetComponent<ComponentHealth>();
            playerHp.SetMaxHp(playerHp.MaxHP + hpValue);
            playerHp.Modify(playerHp.MaxHP - playerHp.CurrHP);
            Destroy(gameObject);
        }
    }
}
