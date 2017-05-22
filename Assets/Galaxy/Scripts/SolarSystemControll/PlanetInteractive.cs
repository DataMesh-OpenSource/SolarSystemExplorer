using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInteractive : MonoBehaviour
{
    //public string planetName;

    private CardControl control;

    void Start()
    {
        control = CardControl.Instance;
    }

    public void OnGazeExitObject()
    {
        control.OnGazePlanet(null);
    }

    public void OnGazeEnterObject()
    {
        control.OnGazePlanet(name);
    }
}
