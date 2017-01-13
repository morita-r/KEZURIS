
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Script : MonoBehaviour {

    public GameObject Cube;
    public GameObject Fragment;
    public int[] id;
    public int[] fallen_id;
	// Use this for initialization
	void Start () {
		
	}

    public void set_Id(int[] _id) {
        id = _id;
    }

    public void set_Fallen_Id(int[] _Fallen_id) {
        fallen_id = _Fallen_id;
    }

    public void Destroy_Cube() {
        Destroy(gameObject);
    }

    public int[] get_fallen_id() { return fallen_id; }
    public int[] get_Id() { return id; }
	// Update is called once per frame
	void Update () {
//        if (Input.GetMouseButtonUp(0))
            //Clicked();
	}

    public void Clicked()
    {
        Vector3 clicked_pos = Input.mousePosition;
        clicked_pos.z = transform.position.z+29;
        if (Cube.transform.position.x - 0.5f < Camera.main.ScreenToWorldPoint(clicked_pos).x
            && Cube.transform.position.x + 0.5f > Camera.main.ScreenToWorldPoint(clicked_pos).x
            && Cube.transform.position.y - 0.5f < Camera.main.ScreenToWorldPoint(clicked_pos).y
            && Cube.transform.position.y + 0.5f > Camera.main.ScreenToWorldPoint(clicked_pos).y)
            Cube_Clicked();
    }

    private void Cube_Clicked() {
        Destroy(Cube);
        transform.parent.GetComponent<Cubes_Script>().Cube_Destroyed(id);
        for (float x = -0.5f; x < 0.5f; x+=0.25f)
            for (float y = -0.5f; y < 0.5f; y+=0.25f)
            {
                Vector3 pos = transform.position;
                pos.x += x;
                pos.y += y;
                GameObject frag_temp = Instantiate(Fragment, pos, Quaternion.identity);
                frag_temp.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-4.0f,4.0f), Random.Range(-4.0f, 4.0f),5), ForceMode.VelocityChange);
            }
    }

    public void Down_Cube() {
        //position下げる
        Vector3 pos = transform.position;
        pos.y -= 1;
        transform.position = pos;
        //fallen_idの更新
        fallen_id[1]--;
    }
}
