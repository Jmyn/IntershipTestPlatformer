using UnityEngine;
using System.Collections;

public class ComponentMovement : MonoBehaviour 
{

	//TODO movement

	float m_speed = 0.1f;
	[SerializeField]
	protected float m_jumpHeight = 11;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

		if (Input.GetKey (KeyCode.A)) 
		{
			//TODO move character left
		}
		else if (Input.GetKey (KeyCode.D)) 
		{
			//TODO move character right
		}
		else if (Input.GetKey (KeyCode.W)) 
		{
			//TODO make character jump
		}

	}
	






}
