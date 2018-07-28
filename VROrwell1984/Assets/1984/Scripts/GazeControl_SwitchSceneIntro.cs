using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*	wechselt die Szene vom IntroRoom in WinstonsRoom
*/

public class GazeControl_SwitchSceneIntro : MonoBehaviour {

	public string SceneToSwitchTo = "";
	public Animator Anime;
	public float MyTime = 0f;

	public Transform RadialProgress;


	
	void Start () {
		Anime = GetComponent<Animator>();
		RadialProgress.GetComponent<Image>().fillAmount = MyTime;
	}
	
	
	public void Update () {
		MyTime += Time.deltaTime;

		RadialProgress.GetComponent<Image>().fillAmount = MyTime/4;


		if(MyTime >=4f )
		{
		SceneManager.LoadScene(SceneToSwitchTo); }
		
	}

	
	public void Resetinator () {
		MyTime = 0f;
		RadialProgress.GetComponent<Image>().fillAmount = MyTime;

	}



}
