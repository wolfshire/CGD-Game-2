using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        if (isLocalPlayer)
        {
            //disable the main camera
            GameObject.Find("SceneCamera").SetActive(false);
            //enable the player script which will enable the player camera
            GetComponent<Player>().enabled = true;
        }
	}
}
