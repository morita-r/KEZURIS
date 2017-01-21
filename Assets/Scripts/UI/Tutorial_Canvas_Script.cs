using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Canvas_Script : MonoBehaviour {
    static Canvas _canvas;
    static Transform _transform;
    // Use this for initialization
    void Start()
    {
        _canvas = GetComponent<Canvas>();
        if (_canvas == null)
            Debug.Log("nullやで");
        _transform = transform;
    }

    public void get_canvas() {
        _canvas = GetComponent<Canvas>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void _SetActive(string name, bool b)
    {
        //        foreach (Transform child in _canvas.transform)
        if (_canvas.transform == null)
            Debug.Log("era-");
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

    public static void SetActive(string name, bool b)
    {
        //        foreach (Transform child in _canvas.transform)
        if (_canvas.transform == null)
            Debug.Log("era-");
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
