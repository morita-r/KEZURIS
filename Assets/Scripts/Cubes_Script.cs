using UnityEngine;

public class Cubes_Script : MonoBehaviour {

    public int[,] cube_list;//if 0:broken or null 1:exist
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
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
            Move_Right();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Move_Left();
    }

    private void Move_Right()
    {
        for (int i = 0; i < 3; i++)
        {
            if (cube_list[9, i] == 1)
            {//右端にブロックあり
                return;
            }
        }
        //右端にブロック無し
        for (int y = 0; y < 3; y++){
            for (int x = 9; x > 0 ; x--)
            {
                cube_list[x, y] = cube_list[x - 1, y];
            }
            cube_list[0, y] = 0;
        }
        //ブロック画像アップデート
        for (int n = 0; n < transform.childCount; n++) {
            Vector3 pos = transform.GetChild(n).transform.position;
            pos.x += 1;
            transform.GetChild(n).transform.position = pos;
            int[] _id = transform.GetChild(n).GetComponent<Cube_Script>().id;
            _id[0]++;
            transform.GetChild(n).GetComponent<Cube_Script>().set_Id(_id);
        }
    }
    private void Move_Left() {
        for (int i = 0; i < 3; i++)
        {
            if (cube_list[0, i] == 1)
            {//左端にブロックあり
                return;
            }
        }
        //左端にブロック無し
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 9; x++)
            {
                cube_list[x, y] = cube_list[x + 1, y];
            }
            cube_list[9, y] = 0;
        }
        //ブロック画像アップデート
        for (int n = 0; n < transform.childCount; n++)
        {
            Vector3 pos = transform.GetChild(n).transform.position;
            pos.x -= 1;
            transform.GetChild(n).transform.position = pos;
            int[] _id = transform.GetChild(n).GetComponent<Cube_Script>().id;
            _id[0]--;
            transform.GetChild(n).GetComponent<Cube_Script>().set_Id(_id);
        }

    }
    public void Cube_Destroyed(int[] _id){
        Debug.Log("ID:(" + _id[0].ToString() + "," + _id[1].ToString() + ") Destroyed.");
        cube_list[_id[0], _id[1]] = 0;
    }
}
