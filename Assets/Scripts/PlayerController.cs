using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary{
	public float xMin,zMin,xMax,zMax;
}

public class PlayerController : MonoBehaviour {

	Rigidbody rb;
	public float speed, tilt;
	public Boundary bounary;
	public GameObject bolt;
	public Transform pos;
	public bool left,right;


	void Awake()
	{
		rb = GetComponent<Rigidbody> ();
		bounary.xMax = (Camera.main.aspect * Camera.main.orthographicSize)-0.5f;
		bounary.xMin = -bounary.xMax;
	}
	void Update () {
		if (Input.GetMouseButtonDown(0))
			Fire ();
	}

	void FixedUpdate()
	{

		Vector3 vel = Input.acceleration;
		vel.z = vel.y;
		vel.y = 0;
		rb.velocity =  vel* speed ;	
		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, bounary.xMin, bounary.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, bounary.zMin, bounary.zMax)
		);

		rb.rotation = Quaternion.Euler (rb.velocity.z, 0.0f, rb.velocity.x * -tilt); 


	}
	public void Fire(){
		
			Instantiate (bolt, pos.position,pos.rotation);
	}


}
