using UnityEngine;
using System.Collections;

public class PowerMagnet : Power {

	[SerializeField]
	private float strength;

	public float Strength { get { return strength; } }

	void Update() {

	}

	public override bool isClone(Power p) {
		return p.GetType() == this.GetType() && ((PowerMagnet)p).strength == this.strength;
	}
}
