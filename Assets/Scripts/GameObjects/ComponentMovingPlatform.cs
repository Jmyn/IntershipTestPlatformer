using UnityEngine;
using System.Collections;

public class ComponentMovingPlatform : MonoBehaviour 
{
    public float maxMove = 3f;
    public float speed = 2;
    public bool left = true;
    private float startTime;
    private float elaspedTime = 0;
	//TODO Moving Platform
	void Start () 
	{
        startTime = Time.time;
	}

    void Update()
    {
        elaspedTime = Time.time - startTime;
        if(elaspedTime >= maxMove) {
            left = !left;
            elaspedTime = 0;
            startTime = Time.time;
        }
    }

	void FixedUpdate()
	{   
        if(left) {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        } else {
            transform.Translate(Vector3.right * Time.deltaTime * speed);

        }
	}
    
   
	
}
