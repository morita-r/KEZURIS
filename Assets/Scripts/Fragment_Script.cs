using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragment_Script : MonoBehaviour {
    MeshRenderer meshrender;
    // Use this for initialization

    public static bool pause = false;
    void Start () {
        meshrender = GetComponent<MeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P)) {
            pause = !pause;
        }
        if (pause)
            return;
        Color _color = meshrender.material.color;
        _color.a-=0.02f;
        if (_color.a < 0)
        {
            Destroy(gameObject);
        }
        meshrender.material.color = _color;
	}
}
