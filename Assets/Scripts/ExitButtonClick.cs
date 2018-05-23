using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonClick : MonoBehaviour {

	public void Click()
    {
        Application.Quit();
    }

    private void OnMouseDown()
    {
        Application.Quit();
    }
}
