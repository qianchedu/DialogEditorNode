using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ChapterPartDefine :  ScriptableObject
{


    [MenuItem("Assets/Create/ChapterPartConfig")]
    static void CreateChapterPartConfig()
    {
        ScriptableObjectUtility.CreateAsset<ChapterPartDefineModel>();
    }

}