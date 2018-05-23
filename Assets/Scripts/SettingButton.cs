using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour {

	public GameObject MainMenuButton;
	public GameObject ExitButton;
	[HideInInspector]
	public GameObject Mmbt;
	[HideInInspector]
	public GameObject Exbt;
	private bool btIsActive;
	public Camera MainCamera;

	void Start() {
		btIsActive = false;
	}

	public void OnMouseDown()
	{
		if (btIsActive) {
			Destroy_buttons ();
			btIsActive = false;
			return;
		}
		btIsActive = true;
		if (GameObject.Find ("Settings").transform.position.x < 0) {
			Mmbt = (Instantiate (MainMenuButton, (new Vector3 (-14.0f, 4.0f, 0.0f)), Quaternion.identity)).gameObject;
			Exbt = (Instantiate (ExitButton, (new Vector3 (-14.0f, 1.0f, 0.0f)), Quaternion.identity)).gameObject;
		} else {
			Mmbt = (Instantiate (MainMenuButton, (new Vector3 (14.0f, -4.0f, 0.0f)), Quaternion.identity)).gameObject;
			Mmbt.transform.rotation = new Quaternion (0.0f, 0.0f, 180.0f, 0.0f);
			Exbt = (Instantiate (ExitButton, (new Vector3 (14.0f, -1.0f, 0.0f)), Quaternion.identity)).gameObject;
			Exbt.transform.rotation = new Quaternion (0.0f, 0.0f, 180.0f, 0.0f);
		}
	}

	public void Destroy_buttons()
	{
		Destroy (Mmbt);
		Destroy (Exbt);
	}

	void Update() {
		/* if (MainCamera.transform.rotation.z != 0.0f && MainCamera.transform.rotation.z != 180.0f) {
			print ("Hello");
			Destroy_buttons ();
		} */
	}

}
