using UnityEngine;
using System.Collections;

public class PickupSpawn : MonoBehaviour {
    public Transform[] spwnPts;
    public GameObject[] pickups;
    public int pickupsPerSpawn = 1;

    private ArrayList pickedPts;
	// Use this for initialization
	void Start () {
        pickedPts = new ArrayList();
	}
	


    public void SpawnPickup()
    {
        for (int i = 0; i < pickupsPerSpawn; i++ )
        {
            //Make sure not to spawn pickups in same spot
            //pickupsPerSpawn must be <= spwnPts
            int rand = Random.Range(0, spwnPts.Length);
            while(pickedPts.Contains(rand)) {
                rand = Random.Range(0, spwnPts.Length);
            }
            pickedPts.Add(rand);

            Transform spwnPt = spwnPts[rand];
            GameObject pickup = Instantiate(pickups[Random.Range(0, pickups.Length)],
                spwnPt.position, Quaternion.identity) as GameObject;
            Destroy(pickup, GameControl.current.pickupsSpawnInterval);
        }
        pickedPts.Clear();

    }

    public void IncreasePickupPerSpawn(int amt)
    {
        pickupsPerSpawn += amt;
        pickupsPerSpawn = Mathf.Min(pickupsPerSpawn, spwnPts.Length);
    }

}
