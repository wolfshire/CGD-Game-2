using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

	// Use this for initialization
	void Start () {

		Debug.Log(isLocalPlayer);
        if (isLocalPlayer)
        {
			Debug.Log("DERP");
            //disable the main camera
            GameObject.Find("SceneCamera").SetActive(false);
            //enable the player script which will enable the player camera
            GetComponent<Player>().enabled = true;
        }
	}
}
