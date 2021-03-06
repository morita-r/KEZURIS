﻿using UnityEngine;
using UnityEngine.UI;

public class Generate_Cube : MonoBehaviour {

    public GameObject Parent_Cubes;
    public static bool tutorial;
    public static bool generate;
    public static int next_num;
    public GameObject[] Prefab_Cubes;
    int time;



	// Use this for initialization
	void Start () {
//        tutorial = true;
        generate = true;
        next_num = Random.Range(0, 10);
        time = 0;
        if (tutorial)
        { Tutorial_Canvas_Script _canvas = GameObject.Find("Canvas").GetComponent<Tutorial_Canvas_Script>();
            _canvas.get_canvas();
            _canvas._SetActive("Button_Start", false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (tutorial) {

        }



        if (generate)
        {
            time++;
            if (time == 30)
            {
                time = 0;
                Initialize_Cubes();
            }
        }
        if (Input.GetKeyDown("space"))
        {
            Initialize_Cubes();
        }


    }

    private void Initialize_Cubes() {
        generate = false;
//        Vector3 init_pos = new Vector3(0,5,0);
        GameObject Parent = Instantiate(Parent_Cubes);
        int[,] list = new int[10, 3];

        //        int param = Random.Range(0, 10);
        //        list = Placement.return_list(param);
        //        Generate_Cubes(Parent, list,param);
        list = Placement.return_list(next_num);
        Generate_Cubes(Parent, list, next_num);
        next_num = Random.Range(0, 10);
        GameObject next_cubes = GameObject.Find("Next_Cubes");
        next_cubes.GetComponent<Next_Cube_Script>().Next_Update(next_num);

    }


    private void Generate_Cubes(GameObject Parent,int[,]list,int param) {
        if (tutorial)
        {

            Parent.GetComponent<Tutorial_Cubes_script>().Initialize(list);
            Parent.GetComponent<Tutorial_Cubes_script>().Set_Speed(Falled_Management.level);
        }else
        {
            Parent.GetComponent<Cubes_Script>().Initialize(list);
            Parent.GetComponent<Cubes_Script>().Set_Speed(Falled_Management.level);

        }
        //        for (int s = 0; s < 3; s++)
        for (int t = 0; t < 10; t++)
        {
            bool is_bottom = true;
            //            for (int t = 0; t < 10; t++)
            for (int s = 0; s < 3; s++)
            {
                if (list[t, s] == 1)
                {
                    GameObject child = Instantiate(Prefab_Cubes[param], new Vector3(t - 4.5f, s + (10* Mathf.Tan(Mathf.PI / 6)), 4), Quaternion.identity);
                    child.transform.parent = Parent.transform;
                    int[] _id = new int[2] {t,s};
                    child.GetComponent<Cube_Script>().set_Id(_id);
                    int[] fallen_id = new int[2] { -1, -1 };
                    child.GetComponent<Cube_Script>().set_Fallen_Id(fallen_id);
                    child.GetComponent<Cube_Script>().set_bottom(is_bottom);
                    is_bottom = false;
                }
            }
        }
    }
}
