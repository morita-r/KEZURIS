using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes_Script : MonoBehaviour {

    public int[,] cube_list;
    bool fall_flag = false;

    public void Initialize(int[,] list)
    {
        cube_list = list;
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        if (fall_flag)
        {
            pos.y -= 0.1f;
        }
        else {
            pos.z -= 0.01f;
            if (pos.z < -10.5f)
                fall_flag = true;
        }
        transform.position = pos;
	}
}
