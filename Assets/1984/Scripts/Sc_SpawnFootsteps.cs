using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
        Damit im OfficeRoom die Fußspuren auf dem Monitor angezeigt werden können, werden sie von einer 
        Kamera aufgenommen, die eine RenderTexture erzeugt.
        Daher müssen die Fußspuren in dieser Szene nochmals als Instanzen eines Prefabs erzeugt werden.
        hierzu wird erst nach dem ScoreManager gesucht, der die entsprechenden Informationen bezüglich
        Position und Rotation gespeichert hat.

        Die Funktion SpawnFootsteps erzeugt für jedes Element der Liste eine Instanz des Prefabs.

        Innerhalb der Update Funktion, wird immer das nächste Element aktiviert und das letzte deaktiviert.
        So entsteht innerhalb der Szene der Eindruck von Bewegung der Fußspuren.
     */

public class Sc_SpawnFootsteps : MonoBehaviour {

    [SerializeField]
    Sc_ScoreManager ManagerScript;

    [SerializeField]
    List<GameObject> Foots;

    public GameObject Foot;

    int Iteration;
    float time;
    // Use this for initialization
    void Start() {
        Iteration = 0;
        time = 0f ;
        try
        {
            ManagerScript = GameObject.Find("ScoreManager").GetComponent<Sc_ScoreManager>();
            SpawnFootsteps();
        }
        catch
        {
            Debug.Log("Something went wrong");
        }
    }
	
    public void SpawnFootsteps()
    {
        int i = 0;
        while(i < ManagerScript.Positions.Count)
        {
            GameObject myTest = Instantiate(Foot, ManagerScript.Positions[i], new Quaternion(0f,ManagerScript.Rotations[i],0f,0f));
            Foots.Add(myTest);
            Foots[i].SetActive(false);
            i++;
        }

    }

	// Update is called once per frame
	void Update () {
        if (Foots.Count > 0)
        {
            time += Time.deltaTime;
            if (time >= 1.5f)
            {
                if (Iteration < Foots.Count - 1 && Iteration != 0)
                {
                    Foots[Iteration - 1].SetActive(false);
                    Foots[Iteration].SetActive(true);
                    Iteration++;
                }
                else if (Iteration < Foots.Count && Iteration != 0)
                {
                    Foots[Iteration - 1].SetActive(false);
                    Foots[Iteration].SetActive(true);
                    Iteration = 0;
                }
                else
                {
                    Foots[Foots.Count - 1].SetActive(false);
                    Foots[Iteration].SetActive(true);
                    Iteration++;
                }
                time = 0f;
            }
        }
	}
}
