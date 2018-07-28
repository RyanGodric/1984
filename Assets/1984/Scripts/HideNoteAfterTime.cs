using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Lässt den eingeblendeten Zettel nach der in MyTime gesetzten Zeit 
// wieder verschwinden

public class HideNoteAfterTime : MonoBehaviour {

	
	public float MyTime = 0f;
	

	
	public void Update () {
		MyTime += Time.deltaTime;

		if(MyTime >=10f) 
		{
		gameObject.SetActive(false);
		MyTime = 0f;

	}
	}

	public void Resetinator () {
		MyTime = 0f;
		

    }



}