using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Cube : MonoBehaviour {

    public GameObject Cube;
    public GameObject Fragment;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
            Clicked();
	}

    private void Clicked()
    {
        Vector3 clicked_pos = Input.mousePosition;
        clicked_pos.z = 10;
        if (Cube.transform.position.x - 0.5f < Camera.main.ScreenToWorldPoint(clicked_pos).x
            && Cube.transform.position.x + 0.5f > Camera.main.ScreenToWorldPoint(clicked_pos).x
            && Cube.transform.position.y - 0.5f < Camera.main.ScreenToWorldPoint(clicked_pos).y
            && Cube.transform.position.y + 0.5f > Camera.main.ScreenToWorldPoint(clicked_pos).y)
            Cube_Clicked();
    }

    private void Cube_Clicked() {
        Destroy(Cube);
        GameObject frag_temp = Instantiate(Fragment,new Vector3(),Quaternion.identity);
        frag_temp.GetComponent<Rigidbody>().AddForce(new Vector3(), ForceMode.VelocityChange);
    }
}
