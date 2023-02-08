using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateButton : MonoBehaviour
{
    //generates the mesh/map when the on screen button is pressed
    public void OnButtonClick()
    {
        GetComponent<MapGenerator>().GenerateMap();
    }
}
