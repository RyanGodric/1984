using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
    Dieses Skript 'hängt' ein GameObject vor die Kamera, in diesem Fall einen Notizzettel
    und ändert den Bewegungszustand, wenn der Player zur Zeit in Bewegung ist.
     */

public class Sc_Note : MonoBehaviour {

    public GameObject NotePage;
    //public Canvas NotePageCanvas;
    private int NoteCounter;

    private Sc_ScoreManager ScoreManager;


	// Use this for initialization
	void Start () {
        ScoreManager = GameObject.Find("ScoreManager").GetComponent<Sc_ScoreManager>();
        NoteCounter = 0;
        try { 
        NotePage.SetActive(false);
        }
        catch(System.Exception e) { Debug.Log(e); }
    }

    public void showNote(GameObject pGameobject)
    {
        NoteCounter++;
        NotePage = pGameobject;
        NotePage.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 1.0f + new Vector3(0f, 0f, 15f);
        if (GetComponent<Fly>().getfly())
        {
            GetComponent<Fly>().changeState();
        }
        NotePage.SetActive(true);
    }
}
