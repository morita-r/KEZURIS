using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Again_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
    }

    // Update is called once per frame

    public void button_again()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("stage");
    }
}
