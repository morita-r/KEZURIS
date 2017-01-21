using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Start : MonoBehaviour {

    private int TUTORIAL_DONE = 1;
    private string TUTORIAL_KEY = "TUTORIAL";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void button_start() {
        int temp = PlayerPrefs.GetInt(TUTORIAL_KEY, 0);
        if (temp == TUTORIAL_DONE)
        {

            UnityEngine.SceneManagement.SceneManager.LoadScene("stage");
            Generate_Cube.tutorial = false;
            Cubes_Script.pause = false;
            Fragment_Script.pause = false;
        }
        else {
            UnityEngine.SceneManagement.SceneManager.LoadScene("tutorial");
            Generate_Cube.tutorial = true;
        }
    }
}
