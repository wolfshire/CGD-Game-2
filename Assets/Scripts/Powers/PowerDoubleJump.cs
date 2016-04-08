using UnityEngine;
using System.Collections;

public class PowerDoubleJump : Power {

	[SerializeField]
	private int numberOfJumps;

	public int NumberOfJumps { get { return numberOfJumps; } }

	public override bool isClone(Power p) {
		return p.GetType() == this.GetType() && ((PowerDoubleJump)p).numberOfJumps == this.numberOfJumps;
	}
}
