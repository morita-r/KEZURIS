using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stage_Highscore_Script : MonoBehaviour {
    private string HIGH_SCORE = "HIGH_SCORE";

    // Use this for initialization
    void Start () {
        int high_score = PlayerPrefs.GetInt(HIGH_SCORE, 0);
        transform.GetComponent<Text>().text = high_score.ToString();
    }
}
