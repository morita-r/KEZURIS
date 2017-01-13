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
            int[] set_id = new int[2] { _id[0], (int)(_id[1] + 20 + Mathf.Round(Cubes.position.y)) };
            list[_id[0], (int)(_id[1] + 20 + Mathf.Round(Cubes.position.y + (10 * Mathf.Tan(Mathf.PI / 6))))] = 1;
            Cubes.GetChild(i).GetComponent<Cube_Script>().set_Fallen_Id(set_id);
        }
    }

    public static void Check_Line()
    {
        bool flag;
        for (int y = 0; y < 20; y++)
        {
            flag = true;
            for (int x = 0; x < 10; x++)
            {
                if (list[x, y] == 0)
                {
                    flag = false;
                    break;
                }
            }
            if (flag) {//1列そろった
                GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
                foreach(GameObject Cube in cubes)
                {
                    int[] _id = Cube.GetComponent<Cube_Script>().get_fallen_id();
                    if (_id[1] == y)
                    {//そろった列
                        Cube.GetComponent<Cube_Script>().Destroy_Cube();
                    }
                }
                List_DeleteLine(y);
                y--;
            }
        }
    }

    private static void List_DeleteLine(int y) {
        for (int i = 0; i < 10; i++)//列削除
            list[i, y] = 0;
        for (int s = y; s < 19; s++) {//列アップデート
            for (int i = 0; i < 10; i++)
                list[i, s] = list[i, s + 1];
        }
        Cube_Update(y);
    }
    private static void Cube_Update(int y) {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach (GameObject Cube in cubes)
        {
            int[] _id = Cube.GetComponent<Cube_Script>().get_fallen_id();
            if (_id[1] > y)
            {//削除列より上
                Cube.GetComponent<Cube_Script>().Down_Cube();
            }
        }
    }

}
