﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void button_pause() {
        Cubes_Script.pause = true;
        Fragment_Script.pause = true;
        gameObject.SetActive(false);
        Canvas_Script.SetActive("Button_Resume", true);
    }

    public void button_resume()
    {
        Cubes_Script.pause = false;
        Fragment_Script.pause = false;
        gameObject.SetActive(false);
        Canvas_Script.SetActive("Button_Pause", true);
    }

}
