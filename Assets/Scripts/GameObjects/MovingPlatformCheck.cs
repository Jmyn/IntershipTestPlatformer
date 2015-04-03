using UnityEngine;
using System.Collections;

public class MovingPlatformCheck : MonoBehaviour {
    private Transform owner;
    void Awake()
    {
        owner = transform.parent;
    }

	// Use this for initialization
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "MovingPlatform")
        {
            owner.parent = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "MovingPlatform")
        {
            owner.parent = null;
        }
    }
}
