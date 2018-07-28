using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    /*
        In der Funktion HandleClick(GameObject pGameObject) wird zunächst der Zustand überprüft. Wenn bereits ein 
        Buch untersucht wird (isDragging) und das übergebene GameObject "Right" oder "Wrong" im Namen haben
        werden die Objekte an die entsprechende Stelle im Raum gelegt und die Counter entsprechend erhöht.
        Ist noch kein Buch ausgewählt, wird überprüft, ob das übergebene Objekt "Buch" im Namen trägt. Falls ja,
        wird das Buch an eine besser einsehbare Stelle im Raum gebracht und der Zustand geändert.
        In jedem Fall werden die Ergebnisse an den ScoreManager weitergeleitet.
     */

public class Sc_MoveBooks : MonoBehaviour {

    [SerializeField]
    private bool isDragging;
    private GameObject isDragged;
    public static int WrongBooks;
    public static int RightBooks;

    public Text Count;
    private bool blink;
    public static int BooksWronglySorted;

    private float blinkTime;

    public Sc_ScoreManager ScoreManager;

	// Use this for initialization
	void Start () {
        isDragging = false;
        isDragged = null;
        WrongBooks = 0;
        RightBooks = 0;
        BooksWronglySorted = 0;
        blinkTime = 0.5f;
        blink = true;
        ScoreManager = GameObject.Find("ScoreManager").GetComponent<Sc_ScoreManager>();
    }
	
    public void HandleClick(GameObject pGameObject)
    {
        if (isDragging) { 
            
            if (pGameObject.name.Contains("Wrong") )
            {
                isDragged.transform.position = new Vector3(-49.84547f, -14.05f + WrongBooks*0.7f, 40.24633f);
                isDragged.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                isDragged.layer = 0;
                if (!isDragged.GetComponent<Sc_BookObject>().wrong)
                {
                    BooksWronglySorted++;
                }
                isDragged = null;
                isDragging = !isDragging;
                
                WrongBooks++;
                Count.text = (WrongBooks + RightBooks).ToString();
            }
            else if (pGameObject.name.Contains("Right"))
            {
                isDragged.transform.position = new Vector3(-34.88f, -3.19f + RightBooks * 0.7f, 23.04f);
                isDragged.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                isDragged.layer = 0;
                if (isDragged.GetComponent<Sc_BookObject>().wrong)
                {
                    BooksWronglySorted++;
                }
                isDragged = null;
                isDragging = !isDragging;
                RightBooks++;
                Count.text = (WrongBooks + RightBooks).ToString();
            }
        }
        else
        {
            if (pGameObject.name.Contains("Buch"))
            {
                isDragging = !isDragging;
                isDragged = pGameObject;
                isDragged.GetComponent<BoxCollider>().enabled = false;
                isDragged.transform.position = new Vector3(-22.40711f, -6.299999f, 63.38784f);
                isDragged.transform.Rotate(-64f, -95.8f, 0f);
            }
        }
        Debug.Log("BücherSortiert : " + (WrongBooks + RightBooks) + "; Davon Falsch : "+ BooksWronglySorted);
        ScoreManager.booksSorted = WrongBooks + RightBooks;
        ScoreManager.booksWrong = BooksWronglySorted;
    }

    /*
     Mit Hilfe der blinkTime wird die aktuelle Zahl der sortierten Bücher blinkend auf dem Bildschirm angezeigt
         */
    void Update() {
        if (isDragged != null)
        blinkTime -= Time.deltaTime;
        if (blinkTime <= 0) {
            blinkTime = 0.5f;
            if(blink == true) {
                Count.text = "";
            }
            else { 
                Count.text = (WrongBooks + RightBooks).ToString();
            }
            blink = !blink;
        }
    }
}
