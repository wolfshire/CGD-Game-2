using UnityEngine;
using System.Collections;

public class UFO : MonoBehaviour {

	[SerializeField]
	private Vector3 direction;
	[SerializeField]
	private float speed;

	public void Init (float speed, Vector3 direction) {
		this.speed = speed;
		this.direction = direction;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = this.transform.position;
		pos += speed * Time.deltaTime * direction;
		this.transform.position = pos;

		if(this.transform.position.z <= 0)
			Destroy (this.gameObject);
	}
}
