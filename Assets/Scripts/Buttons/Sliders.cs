using System;
using TMPro;
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

    bool isRightPressed;
    bool isLeftPressed;

    private void Update()
    {
        //while the button is being pressed call these functions
        if (isRightPressed)
        {
            OnRotateRightButtonPressed();
        }
        if (isLeftPressed)
        {
            OnRotateLeftButtonPressed();
        }
    }
    //togle for bool value
    public void ToggleRightPressed(bool value)
    {
        isRightPressed = value;
    }
    //togle for bool value
    public void ToggleLeftPressed(bool value)
    {
        isLeftPressed = value;
    }

    //rotates the mesh and the plane to the LEFT on the Y axis
    public void OnRotateLeftButtonPressed()
    {
        mesh.transform.Rotate(0.0f, 0.1f, 0.0f, Space.Self);
        plane.transform.Rotate(0.0f, 0.1f, 0.0f, Space.Self);

    }

    //rotates the mesh and the plane to the RIGHT on the Y axis
    public void OnRotateRightButtonPressed()
    {
        mesh.transform.Rotate(0.0f,  -0.1f, 0.0f, Space.Self);
        plane.transform.Rotate(0.0f,  -0.1f, 0.0f, Space.Self);

    }

    //called when the show mesh button is pressed
    public void OnShowMeshPressed()
    {
        mesh.SetActive(true);
        plane.SetActive(false);
        mapGenerator.drawMode = MapGenerator.DrawMode.Mesh;
        mapGenerator.GenerateMap();
        showMeshButton.GetComponent<Image>().color = Color.green;
        showColorMapButton.GetComponent<Image>().color = Color.white;
        showNoiseMapButton.GetComponent<Image>().color = Color.white;
    }

    //called when color map button is pressed
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

    //called when show noise map button is pressed
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

    //changes the meshHeightMultiplier variable number to what is in the mesh height input field
    public void MeshHeightInputField()
    {
        mapGenerator.meshHeightMultiplier = Convert.ToInt32(meshHeightInputField.text);
    }

    //changes the X Offset variable number to what is in the x Offset input field

    public void XOffsetInputFieldValue()
    {
        mapGenerator.offset[0] = Convert.ToInt32(xOffsetInputField.text);
    }

    //changes the Y Offset variable number to what is in the y Offset input field
    public void YOffsetInputFieldValue()
    {
        mapGenerator.offset[1] = Convert.ToInt32(yOffsetInputField.text);
    }

    //changes the seed variable number to what is in the seed input field
    public void SeedValueInputField()
    {
        mapGenerator.seed = Convert.ToInt32(seedInputField.text);

    }
    
    //sets the octaaves value and changes the text next to the slider
    public void OctavesSlider()
    {
        mapGenerator.octaves = (int)octavesScaleSlider.value;
        octavesScaleSliderValue.text = mapGenerator.octaves.ToString();
    }

    //sets the persistance value and changes the text next to the slider
    public void PersistanceSlider()
    {
        
        mapGenerator.persistance = (float)persistanceScaleSlider.value;
        persistanceScaleSliderValue.text = mapGenerator.persistance.ToString("0.00");
    }

    //sets the lacunarity value and changes the text next to the slider
    public void LacunaritySlider()
    {
        mapGenerator.lacunarity = (int)lacunarityScaleSlider.value;
        lacunarityScaleSliderValue.text = mapGenerator.lacunarity.ToString();
    }
    //sets the noise value and changes the text next to the slider
    public void NoiseScaleSlider()
    {
        mapGenerator.noiseScale = noiseScaleSlider.value;
        noiseScaleSliderValue.text = noiseScaleSlider.value.ToString("0.0");
    }

    //sets the map width value with the one in the input field
    public void MapWidthInputField()
    {
        mapGenerator.mapWidth = Convert.ToInt32(widthInputField.text);
        
    }

    //sets the map height value with the one in the input field
    public void MapHeightInputField()
    {
        mapGenerator.mapHeight = Convert.ToInt32(heightInputField.text);
    }


   
}
