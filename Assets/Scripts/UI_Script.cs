using System.Collections;
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
        Cubes_Script.pause = !Cubes_Script.pause;
        Fragment_Script.pause = !Fragment_Script.pause;
        Debug.Log("Click");

    }
}
