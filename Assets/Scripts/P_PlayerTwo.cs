using UnityEngine;
using System.Collections;

public class P_PlayerTwo : MonoBehaviour {
	
	Rigidbody r;
	bool canJump;
	bool inTrigger;
	
	[SerializeField]
	int speed = 10;
	
	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody>();
		canJump = true;
	}
	
	// Update is called once per frame
	void Update () {
		//controls
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(Vector3.left * Time.deltaTime * speed);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector3.right * Time.deltaTime * speed);
		}
		if (Input.GetKeyDown(KeyCode.Return) && canJump)
		{
			r.velocity = new Vector3(r.velocity.x, 0, r.velocity.z);
			r.AddForce(Vector3.up * 300 * JumpMultiplier);
			canJump = false;
		}
		if(r.velocity.y < 0 && !inTrigger)
		{
			canJump = false;
		}
		if (this.transform.position.y <=-10)
		{
			transform.position = new Vector3(0, 0, 0f);
		}
	}
	
	//enter the collider of a UFO
	void OnTriggerEnter(Collider o) 
	{
		if(o.tag == "UFO" || o.tag == "Spawner")
		{
			canJump = true;
			inTrigger = true;
		}
	}
	
	//exit the collider of a UFO
	void OnTriggerExit(Collider o)
	{
		if (o.tag == "UFO")
		{
			inTrigger = false;
		}
	}
	
	private float JumpMultiplier { 
		get {
			float mul = 1;
			PowerJump[] jumps = GetComponents<PowerJump> ();
			foreach (PowerJump j in jumps) {
				mul *= j.JumpMultiplier;
			}
			return mul;
		}
	}
}