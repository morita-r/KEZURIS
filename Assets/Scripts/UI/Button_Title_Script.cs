﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Title_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void button_title()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("title");
    }
}
