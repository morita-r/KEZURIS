using UnityEngine;

public class Cubes_Script : MonoBehaviour {

    public int[,] cube_list;//if 0:broken or null 1:exist
    bool fall_flag = false;
    bool stop_flag = false;
    public float slide_speed;
    public float fall_speed;

    public void Initialize(int[,] list)
    {
        cube_list = list;
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (stop_flag)
            return;

        Vector3 pos = transform.position;
        if (fall_flag)//落下中
        {
            for (int n = 0; n < transform.childCount; n++)
            {
                if (Check_underBlock(transform.GetChild(n)))//下にブロックありor壁
                {
                    stop_flag = true;
                    //縦ポジション丸め込み（位置調整）
                    Vector3 pos_Cubes = transform.position;
                    pos_Cubes.y = Mathf.RoundToInt(pos_Cubes.y);
                    transform.position = pos_Cubes;



                    Falled_Management.List_Update(transform);//Falledのリストアップデート
                    Falled_Management.Check_Line();//列確認
                    //列削除（リストアップデート）
                    //段下げる
                    return;
                }
            }
            pos.y -= fall_speed;
            transform.position = pos;

        }
        else {//制御可能
            pos.z -= slide_speed;
            if (Input.GetKeyDown(KeyCode.RightArrow))
                Move_Right();
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                Move_Left();
            if (pos.z < -10.5f)
            {
                fall_flag = true;
                Generate_Cube.generate = true;
            }
            if (transform.childCount == 0)
            {//全部削除された
                Generate_Cube.generate = true;
                Destroy(gameObject);
            }
            transform.position = pos;
        }



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

    private bool Check_underBlock(Transform block) {//まだ落ちるかどうかを判定
        int depth=0;
        for (int i = 19; i > 0; i--) {
            if (Falled_Management.list[(int)(block.position.x+4.5), i] == 1) {//一番上のブロックを探索
                depth = i+1;
                break;
            }
        }
        if(block.position.y < -20+depth)
            return true;
        return false;
    }

}
