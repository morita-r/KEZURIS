using UnityEngine;

public class Generate_Cube : MonoBehaviour {

    public GameObject Parent_Cubes;
    public GameObject Cube;
    public static bool generate;



	// Use this for initialization
	void Start () {
        generate = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (generate)
        {
            Initialize_Cubes();
        }
        if (Input.GetKeyDown("space"))
        {
            Initialize_Cubes();
        }


    }

    private void Initialize_Cubes() {
        generate = false;
        GameObject Parent = Instantiate(Parent_Cubes);
        int[,] list = new int[10, 3];


        //Generate_Sample
        /*        for (int s = 0; s < 3; s++)
                    for (int t = 0; t < 10; t++)
                        if((s+t)%3==0)
                        list[t, s] = 1;
                        */

        list[3, 0] = 1;
        list[3, 1] = 1;
        list[2, 1] = 1;
        list[2, 2] = 1;

        Generate_Cubes(Parent, list);
    }


    private void Generate_Cubes(GameObject Parent,int[,]list) {
        Parent.GetComponent<Cubes_Script>().Initialize(list);
        for (int s = 0; s < 3; s++)
        {
            for (int t = 0; t < 10; t++)
            {
                if (list[t, s] == 1)
                {
                    GameObject child = Instantiate(Cube, new Vector3(t-4.5f, s, 5), Quaternion.identity);
                    child.transform.parent = Parent.transform;
                    int[] _id = new int[2] {t,s};
                    child.GetComponent<Cube_Script>().set_Id(_id);
                    int[] fallen_id = new int[2] { -1, -1 };
                    child.GetComponent<Cube_Script>().set_Fallen_Id(fallen_id);
                }
            }
        }
    }
}
