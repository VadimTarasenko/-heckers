using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showTextInButtons : MonoBehaviour {

    public float speed = 0.01f;
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    }

    private void Update()
    {
        if(text.color.a < 1)
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a+speed );
    }

}
//text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.PingPong(Time.time, 1.0f));