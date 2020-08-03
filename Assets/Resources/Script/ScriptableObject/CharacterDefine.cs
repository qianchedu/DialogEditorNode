using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterDefine : ScriptableObject
{
   
    [MenuItem("Assets/Create/PlayerConfig")]
    static void CreatePlayerConfigDenfine()
    {
        ScriptableObjectUtility.CreateAsset<CharacterDefineModel>();
    }

}
