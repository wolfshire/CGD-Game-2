using UnityEngine;
using System.Collections;

public class PowerJump : Power {

	[SerializeField]
	private float jumpMultiplier;

	public float JumpMultiplier { get { return jumpMultiplier; } }

	public override bool isClone(Power p) {
		return p.GetType() == this.GetType() && ((PowerJump)p).jumpMultiplier == this.jumpMultiplier;
	}
}
