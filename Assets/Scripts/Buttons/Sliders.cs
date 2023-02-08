using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;


public class Sliders : MonoBehaviour
{
    public MapDisplay mapDisplay;
    public MapGenerator mapGenerator;

    public Slider noiseScaleSlider;
    public TextMeshProUGUI noiseScaleSliderValue;

    public Slider octavesScaleSlider;
    public TextMeshProUGUI octavesScaleSliderValue;

    public Slider persistanceScaleSlider;
    public TextMeshProUGUI persistanceScaleSliderValue;


    public Slider lacunarityScaleSlider;
    public TextMeshProUGUI lacunarityScaleSliderValue;

    public TMP_InputField widthInputField;
    public TMP_InputField heightInputField;
    public TMP_InputField seedInputField;
    public TMP_InputField xOffsetInputField;
    public TMP_InputField yOffsetInputField;
    public TMP_InputField meshHeightInputField;

    public Button showMeshButton;
    public Button showColorMapButton;
    public Button showNoiseMapButton;

    public Button rotateLeftButton;
    public Button rotateRightButton;

    public GameObject mesh;
    public GameObject plane;



    public void OnRotateLeftButtonPressed()
    {
        mesh.transform.Rotate(0.0f, Time.time + 10.0f, 0.0f, Space.Self);
    }
    public void OnRotateRightButtonPressed()
    {
        float rotSpeed = 10.0f;

        //while (true)
        //{
        mesh.transform.Rotate(0.0f,  rotSpeed * -10.0f, 0.0f, Space.Self);
        //    break;
        //}
    }
    public void OnShowMeshPressed()
    {
        mesh.SetActive(true);
        plane.SetActive(false);
        mapGenerator.drawMode = MapGenerator.DrawMode.Mesh;
        mapGenerator.GenerateMap();
        showMeshButton.GetComponent<Image>().color = Color.green;
        showColorMapButton.GetComponent<Image>().color = Color.white;
        showNoiseMapButton.GetComponent<Image>().color = Color.white;


        //mapGenerator.drawMode = MapGenerator.DrawMode.Mesh ? showMeshButton.GetComponent<Image>().color = Color.green : showMeshButton.GetComponent<Image>().color = Color.white;
    }

    public void OnShowColorMapPressed()
    {
        mesh.SetActive(false);
        plane.SetActive(true);
        mapGenerator.drawMode = MapGenerator.DrawMode.ColourMap;
        mapGenerator.GenerateMap();
        showMeshButton.GetComponent<Image>().color = Color.white;
        showColorMapButton.GetComponent<Image>().color = Color.green;
        showNoiseMapButton.GetComponent<Image>().color = Color.white;

    }
    public void OnShowNoiseMapPressed()
    {
        mesh.SetActive(false);
        plane.SetActive(true);
        mapGenerator.drawMode = MapGenerator.DrawMode.NoiseMap;
        mapGenerator.GenerateMap();
        showMeshButton.GetComponent<Image>().color = Color.white;
        showColorMapButton.GetComponent<Image>().color = Color.white;
        showNoiseMapButton.GetComponent<Image>().color = Color.green;
    }

    public void MeshHeightInputField()
    {
        mapGenerator.meshHeightMultiplier = Convert.ToInt32(meshHeightInputField.text);
    }

    public void XOffsetInputFieldValue()
    {
        mapGenerator.offset[0] = Convert.ToInt32(xOffsetInputField.text);
    }

    public void YOffsetInputFieldValue()
    {
        mapGenerator.offset[1] = Convert.ToInt32(yOffsetInputField.text);
    }

    public void SeedValueInputField()
    {
        mapGenerator.seed = Convert.ToInt32(seedInputField.text);

    }

    public void OctavesSlider()
    {
        mapGenerator.octaves = (int)octavesScaleSlider.value;
        octavesScaleSliderValue.text = mapGenerator.octaves.ToString();
    }

    public void PersistanceSlider()
    {
        
        mapGenerator.persistance = (float)persistanceScaleSlider.value;
        persistanceScaleSliderValue.text = mapGenerator.persistance.ToString("0.00");
    }

    public void LacunaritySlider()
    {
        mapGenerator.lacunarity = (int)lacunarityScaleSlider.value;
        lacunarityScaleSliderValue.text = mapGenerator.lacunarity.ToString();
    }
    

   public void MapWidthInputField()
    {
        mapGenerator.mapWidth = Convert.ToInt32(widthInputField.text);
        
    }

    public void MapHeightInputField()
    {
        mapGenerator.mapHeight = Convert.ToInt32(heightInputField.text);
    }

    public void NoiseScaleSlider()
    {
        mapGenerator.noiseScale = noiseScaleSlider.value;
        noiseScaleSliderValue.text = noiseScaleSlider.value.ToString("0.0");
    }

   
}
