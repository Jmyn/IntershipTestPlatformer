using UnityEngine;
using System.Collections;

public class ComponentMovingPlatform : MonoBehaviour 
{
    public float maxMove = 3f;
    private bool left = true;
    private float startX;
    private float leftEnd;
    private float rightEnd;
	//TODO Moving Platform
	void Start () 
	{
        startX = transform.position.x;
        leftEnd = startX - maxMove;
        rightEnd = startX + maxMove;
	}

	void FixedUpdate()
	{   
        if(transform.position.x < leftEnd) {
            left = false;
        } 
        if(transform.position.x > rightEnd) {
            left = true;
        }
        if(left) {
            transform.Translate(Vector3.left * Time.deltaTime);
        } else {
            transform.Translate(Vector3.right * Time.deltaTime);

        }
	}
	
}
