﻿using System.Collections;
using System.Collections.Generic;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;

public class DB : MonoBehaviour
{
    private void Start()
    {
        GetDBFilePath();
        DataBaseRead("Select * From Word");
    }
    #region DB생성
    IEnumerator DBCreate()
    {
        string filepath = string.Empty; // 파일경로
        if (Application.platform == RuntimePlatform.Android) // 안드로이드일때
        {
            filepath = Application.persistentDataPath + "/Word.db"; // 안드로이드용 경로설정
            if (!File.Exists(filepath))
            {
                UnityWebRequest unityWebRequest = UnityWebRequest.Get("jar:file://" + Application.dataPath + "!/assets/Word.db");
                unityWebRequest.downloadedBytes.ToString();
                yield return unityWebRequest.SendWebRequest().isDone;
                File.WriteAllBytes(filepath, unityWebRequest.downloadHandler.data);
                //파일을 복사하여 옮기는코드
                //기존예시들이 www클래스로 되어있는데 unity에서는 www클래스를 권장하지않음
                //또한 코루틴을 사용하여 busy waiting을 하지않도록 코드를 작성함
                //기존에 참고한 예시들은 while문을 이용한 대기들이 많음
            }
        }
        else // PC
        {
            filepath = Application.dataPath + "/Word.db"; //경로설정
            if (!File.Exists(filepath))
            {
                File.Copy(Application.streamingAssetsPath + "/Word.db", filepath);  //경로로 파일복사
            }
        }
        Debug.Log("성공");
    }
    #endregion
    #region DB복사
    public string GetDBFilePath()
    {
        string str = string.Empty;
        if (Application.platform == RuntimePlatform.Android)
        {
            str = "URl=file:" + Application.persistentDataPath + "/Word.db";
        }
        else
        {
            str = "URl=file:" + Application.dataPath + "/Word.db";
        }
        return str;
    }
    #endregion
    #region DB연결체크
    public void DBConnectionCheck()
    {
        try
        {
            string dblocate;
#if UNITY_EDITOR
            dblocate = @"Data Source=D:\Git\ArWordBook\ARWordBook\Assets\StreamingAssets\Word.db.db;Pooling=true;FailIfMissing=false;Version=3";
#endif
#if UNITY_ANDROID
            dblocate = (Application.dataPath + "/Word.db;Pooling=true;FailIfMissing=false;Version=3");
#endif
            IDbConnection dbConnection = new SqliteConnection(dblocate);
            dbConnection.Open();
            if (dbConnection.State == ConnectionState.Open)
            {
                Debug.Log("연결성공");
            }
            else
            {
                Debug.Log("연결실패");
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    #endregion
    #region DB읽기
    public void DataBaseRead(string query)//인자로 쿼리문을 받음
    {
        string dblocate;
#if UNITY_EDITOR
        dblocate = @"Data Source=D:\Git\ArWordBook\ARWordBook\Assets\StreamingAssets\Word.db;Pooling=true;FailIfMissing=false;Version=3";
#endif
#if UNITY_ANDROID
        dblocate = (Application.dataPath + "/Word.db;Pooling=true;FailIfMissing=false;Version=3");
#endif
        IDbConnection dbConnection = new SqliteConnection(dblocate);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = query;      //쿼리입력
        IDataReader dataReader = dbCommand.ExecuteReader(); // 쿼리실행
        while (dataReader.Read())
        {
            Debug.Log(dataReader.GetInt32(0) + "," + dataReader.GetString(1) + "," + dataReader.GetString(2));
            //0,1,2필드 읽기
        }
        dataReader.Dispose();       //생성순서와 반대로 닫음
        dataReader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();   // DB에는 1개의 쓰레드만이 접근할수있고 동시접근시 에러
        dbConnection = null;
    }
    #endregion
    #region DB 삽입
    public void DataBaseInsert(string query)//인자로 쿼리문을 받음
    {
        string dblocate;
#if UNITY_EDITOR
        dblocate = @"Data Source=D:\Git\ArWordBook\ARWordBook\Assets\StreamingAssets\Word.db;Pooling=true;FailIfMissing=false;Version=3";
#endif
#if UNITY_ANDROID
        dblocate = (Application.dataPath + "/Word.db;Pooling=true;FailIfMissing=false;Version=3");
#endif
        IDbConnection dbConnection = new SqliteConnection(dblocate);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = query;      //쿼리입력
        IDataReader dataReader = dbCommand.ExecuteReader(); // 쿼리실행
        while (dataReader.Read())
        {
            Debug.Log(dataReader.GetInt32(0) + "," + dataReader.GetString(1) + "," + dataReader.GetString(2));
            //0,1,2필드 읽기
        }
        dataReader.Dispose();       //생성순서와 반대로 닫음
        dataReader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();   // DB에는 1개의 쓰레드만이 접근할수있고 동시접근시 에러
        dbConnection = null;
    }
    #endregion
    #region DB 삭제
    public void DataBaseDelete(string query)//인자로 쿼리문을 받음
    {
        string dblocate;
#if UNITY_EDITOR
        dblocate = @"Data Source=D:\Git\ArWordBook\ARWordBook\Assets\StreamingAssets\Word.db;Pooling=true;FailIfMissing=false;Version=3";
#endif
#if UNITY_ANDROID
        dblocate = (Application.dataPath + "/Word.db;Pooling=true;FailIfMissing=false;Version=3");
#endif
        IDbConnection dbConnection = new SqliteConnection(dblocate);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = query;      //쿼리입력
        IDataReader dataReader = dbCommand.ExecuteReader(); // 쿼리실행
        while (dataReader.Read())
        {
            Debug.Log(dataReader.GetInt32(0) + "," + dataReader.GetString(1) + "," + dataReader.GetString(2));
            //0,1,2필드 읽기
        }
        dataReader.Dispose();       //생성순서와 반대로 닫음
        dataReader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();   // DB에는 1개의 쓰레드만이 접근할수있고 동시접근시 에러
        dbConnection = null;
    }
#endregion
}
