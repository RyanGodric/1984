using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
     Dieses Script erzeugt in WinstonsRoom die Fu�spuren, sollte der Spieler sich bewegen.
     Zun�chst wird in der Start() Funktion eine erste Instanz des im Projekt angelegten
     Prefabs erstellt, diese �bernimmt angepasste Position und Rotation der Hauptkamera und wird
     einer Liste angeh�ngt.
     Danach versucht die Funktion das Gameobjekt mit dem namen "ScoreManager" zu finden, dem danach die Position der 'Fu�-Instanz'
     als auch die Y-Rotation �bergeben wird.
     In der Update-Funktion wird �berpr�ft, ob bereits 1,5 Sekunden vergangen sind, wenn ja wird eine neue Fu�spuren-Instanz
     geladen und deren Position und Rotation an die Kamera angepasst sowie an den "ScoreManager" �bergeben.
     */

public class Sc_Footsteps : MonoBehaviour {
	[SerializeField]
	GameObject Position;
	[SerializeField]
	GameObject Rotation;
	[SerializeField]
	GameObject Foot;

	float timeUpd;

	List<GameObject> Footsteps = new List<GameObject>();

    [SerializeField]
    Sc_ScoreManager ManagerScript;


	void Start () {
		GameObject myTest = Instantiate (Foot,new Vector3(Position.transform.position.x, -33, Position.transform.position.z), Rotation.transform.rotation);
		myTest.transform.rotation = Rotation.transform.rotation;
		Footsteps.Add (myTest);
        try {
            ManagerScript = GameObject.Find("ScoreManager").GetComponent<Sc_ScoreManager>();
            ManagerScript.Rotations.Add(Rotation.transform.rotation.y);
            ManagerScript.Positions.Add(myTest.transform.position);
        }
        catch {
            Debug.Log("Something went wrong");
        }
	}
	

	void Update () {
		timeUpd += Time.deltaTime;
        if (GetComponentInParent<Fly>())
        {
            if (timeUpd >= 1.5 && GetComponentInParent<Fly>().getfly())
            {
                GameObject myTest = Instantiate(Foot, new Vector3(Position.transform.position.x, -33, Position.transform.position.z), Rotation.transform.rotation);
                Footsteps.Add(myTest);
                ManagerScript.Rotations.Add(Rotation.transform.rotation.y);
                ManagerScript.Positions.Add(myTest.transform.position);
                timeUpd = 0;
            }
        }

	}
}
