﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour {
    public AudioSource BgmPlayer;
    public SpriteRenderer BgRender;
    public AudioSource VoicePlayer;
    public Text CharacterName;
    public Text Content;
    public SpriteRenderer Character1;
    public SpriteRenderer Character2;
    public SpriteRenderer Character3;

    /***打印机变量***/
    public float charsPerSeconds = 0.2f;
    private string content;
    private Text textTest;
    private float timer;
    private int currentPos;
    public bool isActive;

    /*****演出*****/
    Dictionary<CharacterDefine, GameObject> characterPool;
    //List<IEnumerable> perfoming;

    void OnEnable() {
        characterPool = new Dictionary<CharacterDefine, GameObject>();
        //perfoming = new List<IEnumerable>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isActive == true)
        {
            StartTyperEffect();
        }
    }


    public void ChangeCharacter(Sprite sprite)
    {
        Character1.sprite = sprite;
    }

    public void PlayBgm(AudioClip clip)
    {
        BgmPlayer.clip = clip;
        BgmPlayer.Play();
    }   

    public void ChangeBg(Sprite bg)
    {
        BgRender.sprite = bg;
    }
    
    public void ChangeUIName(string charaName)
    {
        CharacterName.text = charaName;
    }

    public void ChangeUIContent(string cont)
    {
        content = cont;
        Content.text = "";
        charsPerSeconds = Mathf.Max(0.01f, charsPerSeconds);
        timer = charsPerSeconds;
        currentPos = 0;
        isActive = true;
    }

    private void StartTyperEffect()
    {
        timer += Time.deltaTime;
        if (timer > charsPerSeconds)
        {
            timer -= charsPerSeconds;
            currentPos++;
            Content.text = content.Substring(0, currentPos);
            if (currentPos >= content.Length)
            {
                FinishTyperEffect();
            }
        }
    }

    public void FinishTyperEffect()
    {
        isActive = false;
        timer = charsPerSeconds;
        currentPos = 0;
        Content.text = content;
    }

    public void PlayVoice(AudioClip clip, Action callback)
    {
        float waitTime = 3f;
        if (clip != null)
        {
            waitTime = clip.length;
            VoicePlayer.clip = clip;
            VoicePlayer.Play();
        }
        else
        {
            VoicePlayer.Stop();
        }
        StartCoroutine(DelayedCallback(waitTime, callback));
    }

    private IEnumerator DelayedCallback(float time,Action callback)
    {
        yield return new WaitForSeconds(time);
        callback();
    }

    public void ClearVoiceCallback() {
        StopAllCoroutines();
    }

    void Stop(float stopTime,Action callback)
    {
        StartCoroutine(StopCoroutine(stopTime, callback));
    }

    IEnumerator StopCoroutine(float stopTime, Action callback)
    {
        yield return new WaitForSeconds(stopTime);
        callback();
    }

    public void EndPerform()
    {

    }
}
