using System.Collections.Generic;
using UnityEngine;

public class ChapterPartDefineModel: ScriptableObject
{
    public AudioClip StartBgm;
    public Sprite BaseBg;
    public Animator Perform;

    public List<GAction> Actions = new List<GAction>();
}