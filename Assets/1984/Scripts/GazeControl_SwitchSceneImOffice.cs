using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*	Das Skript lädt, wenn es durch Anschauen des Ausgangs
 aus dem Office aktiviert wurde, je nachdem ob genügend Bücher richtig
 sortiert wurden die Szene ControlRoom oder TortureRoom, oder führt
 keine Aktion aus wenn noch nicht ausreichend Bücher sortiert wurden.
*/

public class GazeControl_SwitchSceneImOffice : MonoBehaviour {

	public Animator Anime;
	public float MyTime = 0f;

	public Transform RadialProgress;

	void Start () {
		Anime = GetComponent<Animator>();
		RadialProgress.GetComponent<Image>().fillAmount = MyTime;
	}
	
	public void Update () {
		MyTime += Time.deltaTime;

		RadialProgress.GetComponent<Image>().fillAmount = MyTime/3;


		if(MyTime >=3f && Sc_MoveBooks.BooksWronglySorted >= 1 )
		{
		SceneManager.LoadScene("TortureRoom"); }

		else if (MyTime >=3f && Sc_MoveBooks.BooksWronglySorted == 0 && Sc_MoveBooks.WrongBooks + Sc_MoveBooks.RightBooks >= 3 ){
			SceneManager.LoadScene("ControlRoom");
		}
	
		
	}

	public void Resetinator () {
		MyTime = 0f;
		RadialProgress.GetComponent<Image>().fillAmount = MyTime;

	}



}