using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Nachdem sich der Kreis gefüllt hat wird die Funktion showNote(einGameObject)
//des Scripts Sc_Note ausgeführt und damit der Zettel eingeblendet

public class GazeControl_ShowNotes : MonoBehaviour {

	public Animator Anime;
	public float MyTime = 0f;
	public Transform RadialProgress;
	public GameObject einGameObject;
	bool fleck;

	
	void Start () {
		Anime = GetComponent<Animator>();
		RadialProgress.GetComponent<Image>().fillAmount = MyTime;
		fleck = false;
	}
	
	
	public void Update () {
		MyTime += Time.deltaTime;

		RadialProgress.GetComponent<Image>().fillAmount = MyTime/2;


		if(MyTime >=2f && fleck != false) 
		{
		GetComponent<Sc_Note>().showNote(einGameObject)
		;
	}
	}

	public void setNote (GameObject temp) {
		einGameObject = temp;
		fleck = true;
	}

	
	public void Resetinator () {
		MyTime = 0f;
		RadialProgress.GetComponent<Image>().fillAmount = MyTime;

    }



}
