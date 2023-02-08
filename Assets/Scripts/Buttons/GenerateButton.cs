using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateButton : MonoBehaviour
{

    public void OnButtonClick()
    {
        GetComponent<MapGenerator>().GenerateMap();
    }
}
