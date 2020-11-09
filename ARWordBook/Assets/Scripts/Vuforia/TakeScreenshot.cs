﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScreenshot : MonoBehaviour {

	[SerializeField]
	GameObject blink;
	[SerializeField]
	Transform blinktrans;

	public void TakeAShot()
	{
		StartCoroutine ("CaptureIt");
	}
	//캡쳐 enumerator
	private IEnumerator CaptureIt()
	{
		string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
		string fileName = "Screenshot" + timeStamp + ".png";
		string pathToSave = fileName;
		ScreenCapture.CaptureScreenshot(pathToSave);
		yield return new WaitForEndOfFrame();
		Instantiate (blink, blinktrans.transform.position, Quaternion.identity);
	}

}
