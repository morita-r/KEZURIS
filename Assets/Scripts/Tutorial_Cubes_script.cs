﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Cubes_script : MonoBehaviour {
    private string TUTORIAL_KEY = "TUTORIAL";
    private int TUTORIAL_DONE = 1;

    public int[,] cube_list;//10*3 if 0:broken or null 1:exist
    bool fall_flag = false;
    bool stop_flag = false;

    bool input_after_pause;
    float slide_speed;
    public float fall_speed;
    int fall_dist;

    Vector3 touch_start_pos;
    Vector3 touch_end_pos;

    int touch_mode;

    const int TOUCH = 0;
    const int SWIPE_RIGHT = 1;
    const int SWIPE_LEFT = 2;
    const int SWIPE_DOWN = 3;
    const int NO_INPUT = -1;
    bool end;
    public static bool pause = false;
    public static int tutorial_num;
    Text tutorial_text;


    float text_time;
    public void Initialize(int[,] list)
    {
        cube_list = list;
    }

    public void Set_Speed(float level)
    {
        slide_speed = level;
    }


    // Use this for initialization
    void Start()
    {
        end = false;
        text_time = 0;
        pause = true;
        if (tutorial_num == 1)
            tutorial_num = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (end)
        {
            if (fall_flag)//落下中
            {
                //new ver
                //            stop_flag = true;
                Vector3 Cubes_pos = transform.position;
                Cubes_pos.y -= fall_speed*Time.deltaTime;
                //            transform.position = Cubes_pos;
                if (Cubes_pos.y <= -26 + fall_dist)
                {//落下完了
                    stop_flag = true;
                    Cubes_pos.y = -26 + fall_dist;
                    //列削除確認
                    Falled_Management.Check_Line();//列確認
                }
                transform.position = Cubes_pos;
            }
            return;//チュートリアル終了ブロック
        }
        if (tutorial_num == 0)
        {
            if (pause)
            {
                tutorial_text = GameObject.Find("Text_Tutorial").GetComponent<Text>();
                text_time+= Time.deltaTime;
                if (text_time < 3)
                {
                    tutorial_text.text = "ブロックは奥から出てくるよ";
                }
                else
                {
                    tutorial_text.text = "右にスワイプしてみよう！" + "\n" + "ブロックを右に動かせるよ";
                }
            }
            switch (Input_Manager())
            {
                case SWIPE_RIGHT:
                    Move_Right();
                    tutorial_text.text = "いいね！" + "\n" + "右に動かせたよ！";
                    pause = false;
                    break;
            }

            if (!pause)
            {
                Vector3 pos1 = transform.position;
                pos1.z -= slide_speed * Time.deltaTime;
                pos1.y -= slide_speed * Mathf.Tan(Mathf.PI / 6) * Time.deltaTime;

                if (pos1.z < -10.1f)
                {
                    pos1.z = -10.1f;
                    fall_flag = true;
                    tutorial_text.text = "ブロックは手前まで移動すると" + "\n" + "下に落ちるよ";
                    end = true;
                    //ここで落下ポジション決定する
                    fall_dist = Determin_Fall(gameObject);//返り値が落ちる高さ

                    tutorial_num = 2;
                    Generate_Cube.generate = true;
                }
                transform.position = pos1;

                if (fall_flag)//落下中
                {
                    //new ver
                    //            stop_flag = true;
                    Vector3 Cubes_pos = transform.position;
                    Cubes_pos.y -= fall_speed * Time.deltaTime;
                    //            transform.position = Cubes_pos;
                    if (Cubes_pos.y <= -26 + fall_dist)
                    {//落下完了
                        stop_flag = true;
                        Cubes_pos.y = -26 + fall_dist;
                        //列削除確認
                        Falled_Management.Check_Line();//列確認
                    }
                    transform.position = Cubes_pos;
                }


                if (transform.childCount == 0)
                {//全部削除された
                    Generate_Cube.generate = true;
                    Destroy(gameObject);
                }
            }

        }
        else if (tutorial_num == 2)
        {
            if (pause)
            {
                text_time+= Time.deltaTime;
                tutorial_text = GameObject.Find("Text_Tutorial").GetComponent<Text>();
                if (text_time > 2)
                {
                    pause = true;
                    tutorial_text.text = "次はブロックを削ってみよう！" + "\n" + "";
                }
                if (text_time > 4)
                {
                    tutorial_text.text = "ブロックをタッチすると" + "\n" + "削れるよ！";
                    switch (Input_Manager())
                    {
                        case TOUCH:
                            for (int n = 0; n < transform.childCount; n++)
                            {
                                transform.GetChild(n).GetComponent<Cube_Script>().Clicked();
                                text_time = 0;
                            }
                            break;
                    }

                }
            }
            else
            {
                tutorial_text = GameObject.Find("Text_Tutorial").GetComponent<Text>();
                text_time+= Time.deltaTime;
                if (text_time < 2)
                {
                    tutorial_text.text = "ナイス！"+"\n"+"これでブロックを操作して" + "\n" + "上手に落とそう！";
                }
                else
                {
                    tutorial_text.text = "削りすぎるとスコアが" + "\n" + "減るから気を付けてね";
                }
                if (!pause)
                {
                    Vector3 pos1 = transform.position;
                    pos1.z -= slide_speed * Time.deltaTime;
                    pos1.y -= slide_speed * Mathf.Tan(Mathf.PI / 6) * Time.deltaTime;

                    if (pos1.z < -10.1f)
                    {
                        pos1.z = -10.1f;
                        fall_flag = true;
                        end = true;
                        //ここで落下ポジション決定する
                        fall_dist = Determin_Fall(gameObject);//返り値が落ちる高さ

                        tutorial_num = 4;
                        Generate_Cube.generate = true;
                    }
                    transform.position = pos1;

                    if (fall_flag)//落下中
                    {
                        //new ver
                        //            stop_flag = true;
                        Vector3 Cubes_pos = transform.position;
                        Cubes_pos.y -= fall_speed * Time.deltaTime;
                        //            transform.position = Cubes_pos;
                        if (Cubes_pos.y <= -26 + fall_dist)
                        {//落下完了
                            stop_flag = true;
                            Cubes_pos.y = -26 + fall_dist;
                            //列削除確認
                            Falled_Management.Check_Line();//列確認
                        }
                        transform.position = Cubes_pos;
                    }


                    if (transform.childCount == 0)
                    {//全部削除された
                        Generate_Cube.generate = true;
                        Destroy(gameObject);
                    }
                }

            }

        }else if(tutorial_num == 4)
        {
            if (pause)
            {
                text_time+= Time.deltaTime;
                tutorial_text = GameObject.Find("Text_Tutorial").GetComponent<Text>();
                if (text_time > 4)
                {
                    tutorial_text.text = "下にスワイプしてみよう！" + "\n" + "ブロックをすぐに落とせるよ";
                    switch (Input_Manager())
                    {
                        case SWIPE_DOWN:
                            Move_Down();
                            tutorial_text.text = "ナイス！" + "\n" + "これで全ての操作だよ";
                            end = true;
                            fall_flag = true;
                            Generate_Cube.generate = true;
                            fall_dist = Determin_Fall(gameObject);//返り値が落ちる高さ

                            tutorial_num = 6;

                            return;
                    }

                }
                else if (text_time > 2)
                {
                    pause = true;
                    tutorial_text.text = "次が最後の操作だよ！" + "\n" + "";
                }


            }


        }else if (tutorial_num == 6)
        {
            tutorial_text = GameObject.Find("Text_Tutorial").GetComponent<Text>();
            text_time+= Time.deltaTime;
            if (text_time > 2)
            {
                tutorial_text.text = "さあ、本番を始めよう！";
                Tutorial_Canvas_Script.SetActive("Button_Start", true);
                PlayerPrefs.SetInt(TUTORIAL_KEY, TUTORIAL_DONE);
                Generate_Cube.tutorial = false;


            }

        }
        /*
        if (pause)
        {
            input_after_pause = true;
            return;
        }


        if (stop_flag)
            return;

        Vector3 pos = transform.position;
        if (fall_flag)//落下中
        {
            //new ver
            //            stop_flag = true;
            Vector3 Cubes_pos = transform.position;
            Cubes_pos.y -= fall_speed;
            //            transform.position = Cubes_pos;
            if (Cubes_pos.y <= -26 + fall_dist)
            {//落下完了
                stop_flag = true;
                Cubes_pos.y = -26 + fall_dist;
                //列削除確認
                Falled_Management.Check_Line();//列確認

                //GAME_OVER確認
                for (int n = 0; n < transform.childCount; n++)
                {
                    int[] _id = transform.GetChild(n).transform.GetComponent<Cube_Script>().get_fallen_id();
                    if (_id[1] >= 21)
                    {//GAME_OVER
                        Debug.Log("GameOver!");
                        Canvas_Script.SetActive("Button_Title", true);
                        Canvas_Script.SetActive("Button_Again", true);
                        Canvas_Script.SetActive("Button_Pause", false);
                        Canvas_Script.SetActive("Text_Result", true);
                        Canvas_Script.SetActive("Text_Result_Label", true);
                        Canvas_Script.SetActive("Text_Gameover", true);


                        Text Score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
                        Text Result = GameObject.FindGameObjectWithTag("Result").GetComponent<Text>();
                        Result.text = Score.text;
                        int score = int.Parse(Score.text);

                        Canvas_Script.SetActive("Text_Score", false);
                        Canvas_Script.SetActive("Text_Score_Label", false);
                        Canvas_Script.SetActive("Text_Highscore", false);
                        Canvas_Script.SetActive("Text_Highscore_Label", false);




//                        Instantiate(gameover_board);
                        Generate_Cube.generate = false;

                        return;

                    }
                }

            }
            transform.position = Cubes_pos;




        }
        else
        {//制御可能
            pos.z -= slide_speed;
            pos.y -= slide_speed * Mathf.Tan(Mathf.PI / 6);
            switch (Input_Manager())
            {
                case NO_INPUT:
                    break;
                case SWIPE_RIGHT:
                    Move_Right();
                    break;
                case SWIPE_LEFT:
                    Move_Left();
                    break;
                case SWIPE_DOWN:
                    Move_Down();
                    return;
                case TOUCH:
                    for (int n = 0; n < transform.childCount; n++)
                    {
                        transform.GetChild(n).GetComponent<Cube_Script>().Clicked();
                    }
                    break;
            }


            if (Input.GetKeyDown(KeyCode.RightArrow))
                Move_Right();
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                Move_Left();
            if (pos.z < -10.1f)
            {
                pos.z = -10.1f;
                fall_flag = true;
                //ここで落下ポジション決定する
                fall_dist = Determin_Fall(gameObject);//返り値が落ちる高さ


                Generate_Cube.generate = true;
            }
            if (transform.childCount == 0)
            {//全部削除された
                Generate_Cube.generate = true;
                Destroy(gameObject);
            }
            transform.position = pos;
        }
        */


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
        for (int y = 0; y < 3; y++)
        {
            for (int x = 9; x > 0; x--)
            {
                cube_list[x, y] = cube_list[x - 1, y];
            }
            cube_list[0, y] = 0;
        }
        //ブロック画像アップデート
        for (int n = 0; n < transform.childCount; n++)
        {
            Vector3 pos = transform.GetChild(n).transform.position;
            pos.x += 1;
            transform.GetChild(n).transform.position = pos;
            int[] _id = transform.GetChild(n).GetComponent<Cube_Script>().id;
            _id[0]++;
            transform.GetChild(n).GetComponent<Cube_Script>().set_Id(_id);
        }
    }
    private void Move_Left()
    {
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

    void Move_Down()
    {
        Vector3 pos = transform.position;
        pos.y = -5.8f;
        pos.z = -10.1f;
        //        fall_flag = true;
        //        Generate_Cube.generate = true;
        transform.position = pos;

    }
    public void Cube_Destroyed(int[] _id)
    {
        Debug.Log("ID:(" + _id[0].ToString() + "," + _id[1].ToString() + ") Destroyed.");
        cube_list[_id[0], _id[1]] = 0;
    }

    private bool Check_underBlock(Transform block)
    {//まだ落ちるかどうかを判定
        int depth = 0;
        for (int i = 19; i > 0; i--)
        {
            if (Falled_Management.list[(int)(block.position.x + 4.5), i] == 1)
            {//一番上のブロックを探索
                depth = i + 1;
                break;
            }
        }
        if (block.position.y < -20 + depth)
            return true;
        return false;
    }

    private int Input_Manager()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touch_start_pos = new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y,
                                        Input.mousePosition.z);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touch_end_pos = new Vector3(Input.mousePosition.x,
                                      Input.mousePosition.y,
                                      Input.mousePosition.z);
            return GetDirection();
        }
        return NO_INPUT;
    }

    private int GetDirection()
    {
        float directionX = touch_end_pos.x - touch_start_pos.x;
        float directionY = touch_end_pos.y - touch_start_pos.y;
        if (Mathf.Abs(directionX) - Mathf.Abs(directionY) > 0)
        {
            if (30 < directionX)
            {
                //右向きにフリック
                touch_mode = SWIPE_RIGHT;
            }
            else if (-30 > directionX)
            {
                //左向きにフリック
                touch_mode = SWIPE_LEFT;
            }
            else
            {
                touch_mode = TOUCH;
            }
        }
        else if (-30 > directionY)
        {
            //下向きにフリック
            touch_mode = SWIPE_DOWN;
            //一気に落ちるやつ
        }
        else
        {
            touch_mode = TOUCH;
        }

        return touch_mode;
    }

    int Determin_Fall(GameObject Cubes)
    {
        int dist = -2;
        for (int i = 0; i < Cubes.transform.childCount; i++)
        {
            for (int k = 22; k >= 0; k--)
            {
                if (Falled_Management.list[(int)(Cubes.transform.GetChild(i).position.x + 4.5), k] == 1)
                {//一番上のブロックを探索
                    int[] _id = Cubes.transform.GetChild(i).GetComponent<Cube_Script>().get_Id();
                    //                    int temp = k + 1 - _id[1];
                    int temp = k - _id[1];
                    bool temp_bool = Cubes.transform.GetChild(i).GetComponent<Cube_Script>().bottom();
                    if (temp > dist && temp_bool)
                        dist = temp;
                    break;
                }
            }
            //下にブロック無し

        }
        //dist:地面（一番上のブロック）からの距離の最短（ここまで落ちる）
        for (int i = 0; i < Cubes.transform.childCount; i++)
        {
            Cubes.transform.GetChild(i).GetComponent<Cube_Script>().fallen_id[0] = Cubes.transform.GetChild(i).GetComponent<Cube_Script>().id[0];
            Cubes.transform.GetChild(i).GetComponent<Cube_Script>().fallen_id[1] = Cubes.transform.GetChild(i).GetComponent<Cube_Script>().id[1] + dist + 1;
            Falled_Management.list[Cubes.transform.GetChild(i).GetComponent<Cube_Script>().fallen_id[0], Cubes.transform.GetChild(i).GetComponent<Cube_Script>().fallen_id[1]] = 1;
        }
        return dist;
    }

    public void Bottom_Update(int[] id)
    {//id:clicked cube
        for (int i = 0; i < 3; i++)
        {
            for (int n = 0; n < transform.childCount; n++)
            {
                int[] _id = transform.GetChild(n).GetComponent<Cube_Script>().get_Id();
                if (id[0] == _id[0] && id[1] == _id[1])//削除ブロックは無視
                    continue;
                if (id[0] == _id[0] && _id[1] == i)
                {//削除ブロックと同列の最下ブロック
                    transform.GetChild(n).GetComponent<Cube_Script>().set_bottom(true);
                    return;
                }
            }
        }
    }
}




