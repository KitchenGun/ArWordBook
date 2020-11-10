﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    public List<string> OcrList { get; set; }

    private int SceneNum=0;
    // Start is called before the first frame update

    void Start()
    {
        
        if(instance == null)
        {
            instance=this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        SceneNum =SceneManager.GetActiveScene().buildIndex;
    }

    public void LateUpdate()
    {
        #region 뒤로가기 키 입력
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (SceneNum)
            {
                case 0:
                    Application.Quit();
                    break;
                case 1:
                    Application.Quit();
                    break;
                case 2:
                    SceneManager.LoadScene(1);
                    break;
            }
        }
        #endregion
    }

    #region 현재씬 확인
    private void OnSceneLoaded()
    {
        SceneNum = SceneManager.GetActiveScene().buildIndex;
    }
    #endregion

    #region 카메라 씬으로 이동
    public void OnCamScene()
    {
        SceneManager.LoadScene(2);
    }
    #endregion

    #region ocr결과를 배열에 저장

    public void SplitManager(string str)
    {
        List<string> ocrlist = str.Split('\n').ToList();
    }

    #endregion
}
