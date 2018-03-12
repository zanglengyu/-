using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class ToolsItem : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    [MenuItem("MyMenu/ClearData")]
    static void Show()
    {
        PlayerPrefs.DeleteAll();

    }
}
