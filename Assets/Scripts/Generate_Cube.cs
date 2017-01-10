using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_Cube : MonoBehaviour {

    public GameObject Parent_Cubes;
    public GameObject Cube;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            Initialize_Cubes();
        }
    }

    private void Initialize_Cubes() {
        GameObject Parent = Instantiate(Parent_Cubes);
        int[,] list = new int[3, 10];
        for (int s = 0; s < 3; s++)
            for (int t = 0; t < 10; t++)
                if((s+t)%3==0)
                list[s, t] = 1;
        Generate_Cubes(Parent, list);
    }


    private void Generate_Cubes(GameObject Parent,int[,]list) {
        Parent.GetComponent<Cubes_Script>().Initialize(list);
        for (int s = 0; s < 3; s++)
        {
            for (int t = 0; t < 10; t++)
            {
                if (list[s, t] == 1)
                {
                    GameObject child = Instantiate(Cube, new Vector3(t-4.5f, s, 5), Quaternion.identity);
                    child.transform.parent = Parent.transform;
                    
                }
            }
        }
    }
}
