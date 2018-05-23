using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollAnimation : MonoBehaviour {

    public float speed = -2f, normPosition = 0f;
    private RectTransform rect;
	// Use this for initialization
	void Start () {
        rect = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {

		if(rect.offsetMin.y != normPosition)
        {
            rect.offsetMin += new Vector2(0f, speed);
            rect.offsetMax += new Vector2(0f, speed);
        }
    }
}
