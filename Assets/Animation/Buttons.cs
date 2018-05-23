using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {

    public AudioClip myAudio;

    public float start_x = 1f, start_y = 1f, start_z = 1f,
                 enter_x = 1.1f, enter_y = 1.1f, enter_z = 1.1f;

    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(enter_x, enter_y, enter_z);
        
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(start_x, start_y, start_z);
    }


}
