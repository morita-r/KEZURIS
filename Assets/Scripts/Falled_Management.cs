using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falled_Management : MonoBehaviour {
    public static int[,] list;
	// Use this for initialization
	void Start () {
        list = new int[10, 20];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void List_Update(Transform Cubes) {
        for (int i = 0; i < Cubes.childCount; i++){//Cubesの子のポジションを元にリストに追加
            int[] _id = Cubes.GetChild(i).GetComponent<Cube_Script>().get_Id();
            list[_id[0], (int)(_id[1] + 20 + Mathf.Round(Cubes.position.y))] = 1;
        }
        int s = 0;
    }


}
