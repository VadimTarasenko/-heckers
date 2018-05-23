using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeClick : MonoBehaviour {

	public void OnMouseDown()
    {
        Application.LoadLevel("MainMenu");
    }
}
