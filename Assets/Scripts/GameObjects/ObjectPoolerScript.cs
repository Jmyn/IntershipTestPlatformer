using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolerScript : MonoBehaviour {
    public static ObjectPoolerScript current;
    public GameObject pooledObject;
    public int poolSize = 20;
    public bool willGrow = true;
    List<GameObject> pool;


    void Awake()
    {
        current = this;
    }
	// Use this for initialization
	void Start () {
        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++ )
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pool.Add(obj);
        }
	}

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pool.Count; i++ )
        {
            if(!pool[i].activeInHierarchy) {
                return pool[i];
            }
        }
        if(willGrow) {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pool.Add(obj);
            return obj;
        }
        return null;
    }


	
}
