using UnityEngine;
using System.Collections;

public class P_Player : MonoBehaviour {

    Rigidbody r;
    bool canJump;
	bool inTrigger;
	int jumpsLeft = 0;
    public GameObject cam;

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
        if (Input.GetKey(KeyCode.A))
        {
			transform.Translate(Vector3.left * Time.deltaTime * speed * SpeedMultiplier);
        }
        if (Input.GetKey(KeyCode.D))
        {
			transform.Translate(Vector3.right * Time.deltaTime * speed * SpeedMultiplier);
        }
		if (Input.GetKeyDown(KeyCode.Space) && (canJump || jumpsLeft > 0))
        {
			r.velocity = new Vector3(r.velocity.x, 0, r.velocity.z);
			r.AddForce(Vector3.up * 300 * JumpMultiplier);
            canJump = false;
			jumpsLeft--;
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
			inTrigger = true;
			jumpsLeft = Jumps;
			canJump = true;
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

	private float SpeedMultiplier { 
		get {
			float mul = 1;
			PowerSpeed[] speed = GetComponents<PowerSpeed> ();
			foreach (PowerSpeed s in speed) {
				mul *= s.SpeedMultiplier;
			}
			return mul;
		}
	}

	private int Jumps { 
		get {
			int num = 0;
			PowerDoubleJump[] jumps = GetComponents<PowerDoubleJump> ();
			if (jumps.Length > 0)
				num = jumps [0].NumberOfJumps;
			return num;
		}
	}
}
