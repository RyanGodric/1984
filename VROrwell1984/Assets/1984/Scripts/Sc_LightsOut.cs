using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
    Deaktiviert alle Lichter in Winstons Room außer das Licht des Fernsehers und die Fußspuren.
    Falls eingesetzt.
     */

public class Sc_LightsOut : MonoBehaviour {

    public GameObject lights;

    private bool LightOn;

    private void Start()
    {
        LightOn = true;
    }

    public void ToogleLights()
    {
        LightOn = !LightOn;
        lights.SetActive(LightOn);
    }
}
