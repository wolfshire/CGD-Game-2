using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class MainMenu : MonoBehaviour {

	private Rect rect;
    public int toolbarInt = 0;
    public string[] toolbarStrings = new string[] { "<- 1P", "2P", "3P", "4P ->" };
	int menu = 0;
	bool justInput = false;
	double cd = 0;
    public GameObject network;
	
	void Start()
	{
		float w = Screen.width / 3 * 2;
		float h = Screen.height / 10f * 7;
		rect = new Rect(Screen.width / 2 - w / 2, Screen.height / 2 - h / 2, w, h);
	}
	
	void OnGUI()
	{
		if (menu == 0) {
			Main ();
		} 
		else if (menu == 1) {
			Controls();
		}
        else if(menu == 2)
        {
            Network();
        }
	}

	void Update(){
        /*
		if (Input.GetAxis ("LeftJoystickX1") > .75 && toolbarInt < 3 && !justInput) {
			justInput = true;
			toolbarInt++;
		}
		if (Input.GetAxis ("LeftJoystickX1") < -.75 && toolbarInt > 0 && !justInput) {
			justInput = true;
			toolbarInt--;
		}
		if (Input.GetButtonDown("Start1"))
		{
			Application.LoadLevel(2);
		}
		if (justInput) {
			cd += Time.deltaTime;
			if(cd > .15){
				cd = 0;
				justInput = false;
			}
		}
        */
	}

	void Main(){
		GUI.Box (rect, "");
		GUILayout.BeginArea (rect);
		GUILayout.BeginVertical ();
		GUILayout.FlexibleSpace ();
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.BeginVertical ();
		GUILayout.Label ("Space Ship Ninja Party");
		GUILayout.FlexibleSpace ();
		GUILayout.EndVertical ();
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		
		toolbarInt = GUILayout.Toolbar (toolbarInt, toolbarStrings);
		Data.players = toolbarInt + 1;
		Data.currentPlayer = 1;
		if (GUILayout.Button ("Play (Local) [Start]", GUILayout.ExpandHeight (true), GUILayout.MaxHeight (200))) {
            Application.LoadLevel(3);
		}
        if (GUILayout.Button("Play Multiplayer Online", GUILayout.ExpandHeight(true), GUILayout.MaxHeight(200)))
        {
            network.GetComponent<NetworkManagerHUD>().enabled = true;
            menu = 2;
        }
        if (GUILayout.Button ("Controls", GUILayout.ExpandHeight (true), GUILayout.MaxHeight (200))) {
			menu = 1;
		}
		if (GUILayout.Button ("Exit", GUILayout.ExpandHeight (true), GUILayout.MaxHeight (200))) {
			Application.Quit ();
		}
		GUILayout.EndVertical ();
		
		GUILayout.EndArea ();
	}

	void Controls(){
		GUI.Box (rect, "");
		GUILayout.BeginArea (rect);
		GUILayout.BeginVertical ();;
		GUILayout.BeginHorizontal ();
		GUILayout.BeginVertical ();
		GUILayout.Label ("WASD: Move");
		GUILayout.Label ("Space: Jump");
		GUILayout.Label ("Esc: Quit To Menu");
		GUILayout.EndVertical ();
		GUILayout.EndHorizontal ();

		if (GUILayout.Button ("Back", GUILayout.ExpandHeight (true), GUILayout.MaxHeight (200))) {
			menu = 0;
		}

		GUILayout.EndVertical ();
		
		GUILayout.EndArea ();
	}

    void Network()
    {
        GUILayout.BeginArea(new Rect(rect.position.x, rect.position.y + Screen.height / 3, rect.width, rect.height / 2));
        GUILayout.BeginVertical(); ;

        if (GUILayout.Button("Back", GUILayout.ExpandHeight(true), GUILayout.MaxHeight(200)))
        {
            network.GetComponent<NetworkManagerHUD>().enabled = false;
            menu = 0;
        }

        GUILayout.EndVertical();

        GUILayout.EndArea();
    }
}
