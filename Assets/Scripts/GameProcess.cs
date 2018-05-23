using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProcess : MonoBehaviour {
	[HideInInspector] public Transform chechs;
	[HideInInspector] public List<GameObject> Chechs_white;
	[HideInInspector] public List<GameObject> Chechs_black;
    [HideInInspector] public GameObject settingButton;
    public Camera mainCamera;

	
    public bool play1;
    public bool play2;

    public static bool double_damka_move = false;
    
    void Start () {
		settingButton = GameObject.Find ("Settings");
        play1 = true;
        play2 = false;
        chechs = GameObject.Find ("Chechs White").transform;
		Chechs_white = new List<GameObject>();

		for (int i = 0; i < chechs.childCount; i++) 
			Chechs_white.Add(chechs.GetChild (i).gameObject);

		chechs = GameObject.Find ("Chechs Black").transform;
		Chechs_black = new List<GameObject>();


		for (int i = 0; i < chechs.childCount; i++)
			Chechs_black.Add(chechs.GetChild (i).gameObject);
	}

	void Update()
	{
		if (play1 == true) {
			settingButton.transform.position = new Vector3 (-14.0f, 7.0f, settingButton.transform.position.z);
			settingButton.transform.rotation = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
		} else {
			settingButton.transform.position = new Vector3 (14.0f, -7.0f, settingButton.transform.position.z);
			settingButton.transform.rotation = new Quaternion (0.0f, 0.0f, 180.0f, 0.0f);
		}
	}
}
