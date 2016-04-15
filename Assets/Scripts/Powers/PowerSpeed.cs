using UnityEngine;
using System.Collections;

public class PowerSpeed : Power {

	[SerializeField]
	private float speedMultiplier;

	public float SpeedMultiplier { get { return speedMultiplier; } }

	public override bool isClone(Power p) {
		return p.GetType() == this.GetType() && ((PowerSpeed)p).speedMultiplier == this.speedMultiplier;
	}
}
