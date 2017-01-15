using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Resume_Script : MonoBehaviour {

    void Start() {
        gameObject.SetActive(false);
    }

    public void button_resume()
    {
        Cubes_Script.pause = false;
        Fragment_Script.pause = false;
        gameObject.SetActive(false);
        Destroy(GameObject.FindGameObjectWithTag("Pause_Board"));

        Canvas_Script.SetActive("Button_Pause", true);
    }
}
