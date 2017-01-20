using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Script : MonoBehaviour {
    static Canvas _canvas;
	// Use this for initialization
	void Start () {
        _canvas = GetComponent<Canvas>();
//        PlayerPrefs.DeleteAll();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void SetActive(string name, bool b)
    {
//        _canvas = GetComponent<Canvas>();
        foreach (Transform child in _canvas.transform)
        {
            // 子の要素をたどる
            if (child.name == name)
            {
                // 指定した名前と一致
                // 表示フラグを設定
                child.gameObject.SetActive(b);
                // おしまい
                return;
            }
        }
        // 指定したオブジェクト名が見つからなかった
        Debug.LogWarning("Not found objname:" + name);
    }
}
