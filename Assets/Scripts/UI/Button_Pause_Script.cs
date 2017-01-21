using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Pause_Script : MonoBehaviour {

    public GameObject pause_board;

    public void button_pause()
    {
        Cubes_Script.pause = true;
        Fragment_Script.pause = true;
        gameObject.SetActive(false);
        Instantiate(pause_board);
        Canvas_Script.SetActive("Button_Resume", true);
        Canvas_Script.SetActive("Button_Title", true);
        Canvas_Script.SetActive("Text_Highscore", false);
        Canvas_Script.SetActive("Text_Highscore_Label", false);

    }
}
