using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    Rigidbody r;
    bool canJump;

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
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            r.AddForce(Vector3.up * 300);
            canJump = false;
        }
    }

    //enter the collider of a UFO
    void OnTriggerEnter(Collider o)
    {
        if(o.tag == "UFO")
        {
            canJump = true;
        }
    }

    //exit the collider of a UFO
    void OnTriggerExit(Collider o)
    {
        if (o.tag == "UFO")
        {
            //canJump = false;
        }
    }
}
