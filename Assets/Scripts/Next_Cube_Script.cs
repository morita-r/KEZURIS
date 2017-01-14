using UnityEngine;

public class Next_Cube_Script : MonoBehaviour{
//    public GameObject Parent_Cubes;
    public static bool generate;
    public GameObject[] Prefab_Cubes;
    GameObject next;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void Next_Update(int param)
    {
        Destroy(next);
        next = Instantiate(Prefab_Cubes[param]);

    }
}
