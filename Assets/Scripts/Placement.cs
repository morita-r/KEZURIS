using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour {
    public static int[,] return_list(int param) {
        int[,] list;
        list = new int[10, 3];//初期化
        switch (param) {
            case 0://右上がり段差
                list[3, 0] = 1;
                list[4, 0] = 1;
                list[4, 1] = 1;
                list[5, 1] = 1;
                list[5, 2] = 1;
                list[6, 2] = 1;
                break;
            case 1://左上がり段差
                list[6, 0] = 1;
                list[5, 0] = 1;
                list[5, 1] = 1;
                list[4, 1] = 1;
                list[4, 2] = 1;
                list[3, 2] = 1;
                break;
            case 2://正方形
                list[3, 0] = 1;
                list[3, 1] = 1;
                list[3, 2] = 1;
                list[4, 0] = 1;
                list[4, 1] = 1;
                list[4, 2] = 1;
                list[5, 0] = 1;
                list[5, 1] = 1;
                list[5, 2] = 1;
                break;
            case 3://長方形
                list[3, 0] = 1;
                list[3, 1] = 1;
                list[4, 0] = 1;
                list[4, 1] = 1;
                list[5, 0] = 1;
                list[5, 1] = 1;
                list[6, 0] = 1;
                list[6, 1] = 1;
                break;
            case 4://L字
                list[3, 0] = 1;
                list[3, 1] = 1;
                list[3, 2] = 1;
                list[4, 0] = 1;
                list[5, 0] = 1;
                list[6, 0] = 1;
                break;
            case 5://逆L字
                list[6, 0] = 1;
                list[6, 1] = 1;
                list[6, 2] = 1;
                list[5, 0] = 1;
                list[4, 0] = 1;
                list[3, 0] = 1;
                break;
            case 6://I字
                list[4, 0] = 1;
                list[4, 1] = 1;
                list[4, 2] = 1;
                break;
            case 7://でかいやつ
                list[2, 0] = 1;
                list[2, 1] = 1;
                list[3, 0] = 1;
                list[3, 1] = 1;
                list[3, 2] = 1;
                list[4, 1] = 1;
                list[4, 0] = 1;
                list[5, 0] = 1;
                list[6, 0] = 1;
                list[6, 1] = 1;
                list[7, 0] = 1;
                list[7, 1] = 1;
                list[7, 2] = 1;
                list[8, 0] = 1;
                list[8, 1] = 1;
                break;
            case 8://十字
                list[2, 1] = 1;
                list[3, 1] = 1;
                list[4, 0] = 1;
                list[4, 1] = 1;
                list[4, 2] = 1;
                list[5, 1] = 1;
                list[6, 1] = 1;
                break;
            case 9://中抜き
                list[3, 0] = 1;
                list[3, 1] = 1;
                list[3, 2] = 1;
                list[4, 0] = 1;
                list[4, 2] = 1;
                list[5, 0] = 1;
                list[5, 2] = 1;
                list[6, 0] = 1;
                list[6, 1] = 1;
                list[6, 2] = 1;
                break;
        }
        return list;
    }

}
