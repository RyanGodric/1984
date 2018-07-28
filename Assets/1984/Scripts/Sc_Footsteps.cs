using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
     Dieses Script erzeugt in WinstonsRoom die Fußspuren, sollte der Spieler sich bewegen.
     Zunächst wird in der Start() Funktion eine erste Instanz des im Projekt angelegten
     Prefabs erstellt, diese übernimmt angepasste Position und Rotation der Hauptkamera und wird
     einer Liste angehängt.
     Danach versucht die Funktion das Gameobjekt mit dem namen "ScoreManager" zu finden, dem danach die Position der 'Fuß-Instanz'
     als auch die Y-Rotation übergeben wird.
     In der Update-Funktion wird überprüft, ob bereits 1,5 Sekunden vergangen sind, wenn ja wird eine neue Fußspuren-Instanz
     geladen und deren Position und Rotation an die Kamera angepasst sowie an den "ScoreManager" übergeben.
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
