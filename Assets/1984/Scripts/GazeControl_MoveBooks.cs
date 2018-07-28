using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// durch anschauen der Bücher wird, nachdem sich der Kreis gefüllt hat,
//die Funktion HandleClick() des Scripts Sc_MoveBooks() ausgeführt

public class GazeControl_MoveBooks : MonoBehaviour {

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
		GetComponent<Sc_MoveBooks>().HandleClick(einGameObject)
		;
	}
	}

	public void setBook (GameObject temp) {
		einGameObject = temp;
		fleck = true;
	}

		public void Resetinator () {
		MyTime = 0f;
		RadialProgress.GetComponent<Image>().fillAmount = MyTime;
    }
}