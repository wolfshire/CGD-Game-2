using UnityEngine;
using System.Collections;

public class MidPoint : MonoBehaviour {

	// Use this for initialization
	GameObject[] gos;
	Vector3 points;
	void Start () {
		gos = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		points = Vector3.zero;
		Debug.Log(gos.Length);
		foreach(GameObject g in gos)
		{
			points += g.transform.position;
		}
		points = points / gos.Length;
		this.transform.position = points;
	}
}
