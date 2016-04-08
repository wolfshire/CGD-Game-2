using UnityEngine;
using System.Collections;
using System.Reflection;

public class UFO : MonoBehaviour {

	[SerializeField]
	private Vector3 direction;
	[SerializeField]
	private float speed;

	[SerializeField]
	private string layer;
	private int ufoLayerMask;
	[SerializeField]
	private float collisionCheck = 5.0f;

	private Power power;

	void Start() {
		power = this.GetComponent<Power> ();
	}

	public void Init (float speed, Vector3 direction) {
		ufoLayerMask = LayerMask.NameToLayer (layer);

		this.speed = speed;
		this.direction = direction;

		this.CheckCollision ();
		this.gameObject.layer = ufoLayerMask;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = this.transform.position;
		pos += speed * Time.deltaTime * direction;
		this.transform.position = pos;

		if(this.transform.position.z <= 0)
			Destroy (this.gameObject);
	}

	void OnTriggerEnter(Collider c) {
		if (power == null)
			return;
		
		Power[] powers = c.GetComponents<Power> ();
		bool found = false;
		foreach (Power p in powers) {
			if (p.isClone (this.power)) {
				found = true;
				break;
			}
		}

		if (!found) {
			CopyComponent (power, c.gameObject);
		}
	}

	void OnTriggerExit(Collider c) {
		if (power == null)
			return;

		Power[] powers = c.GetComponents<Power> ();
		Power found = null;
		foreach (Power p in powers) {
			if (p.isClone (this.power)) {
				found = p;
				break;
			}
		}

		if (found != null) {
			Destroy (found);
		}
	}

	public void CheckCollision() {
		if (Physics.CheckSphere (this.transform.position, collisionCheck, (int)Mathf.Pow(2, ufoLayerMask))) {
			Destroy (this.gameObject);
		}
	}

	Component CopyComponent(Component original, GameObject destination)
	{
		System.Type type = original.GetType();
		Component copy = destination.AddComponent(type);
		// Copied fields can be restricted with BindingFlags
		System.Reflection.FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic); 
		foreach (System.Reflection.FieldInfo field in fields)
		{
			field.SetValue(copy, field.GetValue(original));
		}
		return copy;
	}
}
