using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using TMPro;
using UnityEngine.UI;

using System.Windows;
using Unity.Collections.LowLevel.Unsafe;

public class SlidersV2 : MonoBehaviour
{
    public MapDisplay mapDisplay;
    public MapGenerator mapGenerator;
    public Camera mainCamera;


    public GameObject topPanelOption1;
    public Button mapSizeSettingsButton;
    public TextMeshProUGUI mapSizeSettingsText;
    public Button meshShapeSettingsButton;
    public TextMeshProUGUI meshShapeSettingsText;
    public Button meshRegionSettingsButton;
    public TextMeshProUGUI meshRegionSettingsText;
    public Button meshExportSettingsButton;
    public TextMeshProUGUI meshExportSettingsText;
    //public GameObject topPanelOption2;
    //public GameObject topPanelOption3;
    //public GameObject topPanelOption4;

    public GameObject rightPanelOption1;
    public GameObject mapWidtAndHeightInputPanel;
    public TMP_InputField mapWidthInputField;
    public TMP_InputField mapHeightInputField;
    public TMP_InputField mapScaleXInputField;
    public TMP_InputField mapScaleZInputField;
    public TMP_InputField meshHeightMultiplierInputField;
    public Slider levelOfDetailSlider;
    public TextMeshProUGUI levelOfDetailSliderValue;

    public TMP_Dropdown dropdown;


    public GameObject rightPanelOption2;
    public TMP_InputField offsetXInputField;
    public TMP_InputField offsetYInputField;
    public TMP_InputField seedInputField;
    public Slider noiseScaleSlider;
    public TextMeshProUGUI noiseScaleSliderValue;
    public Slider octaveScaleSlider;
    public TextMeshProUGUI octaveScaleSliderValue;
    public Slider lacunarityScaleSlider;
    public TextMeshProUGUI lacunarityScaleSliderValue;
    public Slider persistanceScaleSlider;
    public TextMeshProUGUI persistanceScaleSliderValue;



    public GameObject rightPanelOption3;
    public Slider deepWaterLevelSlider;
    public TextMeshProUGUI deepWaterLevelValue;
    public Slider waterLevelSlider;
    public TextMeshProUGUI waterLevelValue;
    public Slider sandLevelSlider;
    public TextMeshProUGUI sandLevelValue;
    public Slider grassLevelSlider;
    public TextMeshProUGUI grassLevelValue;
    public Slider rockLevelSlider;
    public TextMeshProUGUI rockLevelValue;
    public Slider snowLevelSlider;
    public TextMeshProUGUI snowLevelValue;


    //tba


    public GameObject rightPanelOption4;
    public Button generateMeshButton;
    public Button exportMeshButton;
    public Button exitApplicationButton;
    public Toggle autoUpdateCheckBox;

    public GameObject showMeshButtonPanel;
    public Button showMeshButton;
    public TextMeshProUGUI showMeshButtonText;

    public GameObject showColorMapButtonPanel;
    public Button showColorMapButton;
    public TextMeshProUGUI showColorMapButtonText;

    public GameObject showNoiseMapButtonPanel;
    public Button showNoiseMapButton;
    public TextMeshProUGUI showNoiseMapButtonText;

    public GameObject showFalloffMapButtonPanel;
    public Button showFalloffMapButton;
    public TextMeshProUGUI showFalloffMapButtonText;

    public GameObject viewSnapButtonPanel;
    public Button viewSnapButton;
    public TextMeshProUGUI viewSnapButtonText;

    public GameObject viewInfoPanel;
    public Button viewInfoButton;
    public GameObject infoPanel;
    public Button InfoPanelCloseButton;


    public GameObject mesh;
    public GameObject plane;

    bool isPressed = false;

    bool isRightPressed;
    bool isLeftPressed;




    private void Start()
    {
        mapGenerator.drawMode = MapGenerator.DrawMode.Mesh;
        mesh.SetActive(true);
        plane.SetActive(false);
        mapWidtAndHeightInputPanel.SetActive(false);

    }

    void Update()
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

    public void ToggleRightPressed(bool value)
    {
        isRightPressed = value;
    }

    public void ToggleLeftPressed(bool value)
    {
        isLeftPressed = value;
    }

    public void ToggleIsPressed(bool pressed)
    {
        isPressed = pressed;
    }

    public void OnRotateLeftButtonPressed()
    {
        mesh.transform.Rotate(0.0f, 0.1f, 0.0f, Space.Self);
        plane.transform.Rotate(0.0f, 0.1f, 0.0f, Space.Self);

    }

    public void OnRotateRightButtonPressed()
    {
        mesh.transform.Rotate(0.0f, -0.1f, 0.0f, Space.Self);
        plane.transform.Rotate(0.0f, -0.1f, 0.0f, Space.Self);


    }

    public void OnMapSizeSettingsButtonPressed()
    {
        rightPanelOption1.SetActive(true);
        rightPanelOption2.SetActive(false);
        rightPanelOption3.SetActive(false);
        rightPanelOption4.SetActive(false);
        mapSizeSettingsButton.GetComponent<Image>().color = Color.white;
        mapSizeSettingsText.GetComponent<TextMeshProUGUI>().color = Color.black;

        meshShapeSettingsButton.GetComponent <Image>().color = Color.black;
        meshShapeSettingsText.GetComponent<TextMeshProUGUI>().color = Color.white;

        meshRegionSettingsButton.GetComponent <Image>().color = Color.black;
        meshRegionSettingsText.GetComponent<TextMeshProUGUI>().color = Color.white;

        meshExportSettingsButton.GetComponent<Image>().color = Color.black;
        meshExportSettingsText.GetComponent<TextMeshProUGUI>().color = Color.white;

    }

    public void OnMeshShapeSettingsButtonPressed()
    {
        rightPanelOption1.SetActive(false);
        rightPanelOption2.SetActive(true);
        rightPanelOption3.SetActive(false);
        rightPanelOption4.SetActive(false);
        mapSizeSettingsButton.GetComponent<Image>().color = Color.black;
        mapSizeSettingsText.GetComponent<TextMeshProUGUI>().color = Color.white;

        meshShapeSettingsButton.GetComponent<Image>().color = Color.white;
        meshShapeSettingsText.GetComponent<TextMeshProUGUI>().color = Color.black;

        meshRegionSettingsButton.GetComponent<Image>().color = Color.black;
        meshRegionSettingsText.GetComponent<TextMeshProUGUI>().color = Color.white;

        meshExportSettingsButton.GetComponent<Image>().color = Color.black;
        meshExportSettingsText.GetComponent<TextMeshProUGUI>().color = Color.white;

    }

    public void OnMeshRegionSettingsButtonPressed()
    {
        rightPanelOption1.SetActive(false);
        rightPanelOption2.SetActive(false);
        rightPanelOption3.SetActive(true);
        rightPanelOption4.SetActive(false);
        
        mapSizeSettingsButton.GetComponent<Image>().color = Color.black; //button color
        mapSizeSettingsText.GetComponent<TextMeshProUGUI>().color = Color.white; //button text color

        meshShapeSettingsButton.GetComponent<Image>().color = Color.black;
        meshShapeSettingsText.GetComponent<TextMeshProUGUI>().color = Color.white;

        meshRegionSettingsButton.GetComponent<Image>().color = Color.white;
        meshRegionSettingsText.GetComponent<TextMeshProUGUI>().color = Color.black;

        meshExportSettingsButton.GetComponent<Image>().color = Color.black;
        meshExportSettingsText.GetComponent<TextMeshProUGUI>().color = Color.white;

    }

    public void OnMeshExportSettingsButtonPressed()
    {
        rightPanelOption1.SetActive(false);
        rightPanelOption2.SetActive(false);
        rightPanelOption3.SetActive(false);
        rightPanelOption4.SetActive(true);

        mapSizeSettingsButton.GetComponent<Image>().color = Color.black; //button color
        mapSizeSettingsText.GetComponent<TextMeshProUGUI>().color = Color.white; //button text color

        meshShapeSettingsButton.GetComponent<Image>().color = Color.black;
        meshShapeSettingsText.GetComponent<TextMeshProUGUI>().color = Color.white;

        meshRegionSettingsButton.GetComponent<Image>().color = Color.black;
        meshRegionSettingsText.GetComponent<TextMeshProUGUI>().color = Color.white;

        meshExportSettingsButton.GetComponent<Image>().color = Color.white;
        meshExportSettingsText.GetComponent<TextMeshProUGUI>().color = Color.black;

    }


    public void OnMapWidthInputFieldChanged()
    {
        mapGenerator.mapWidth = Convert.ToInt32(mapWidthInputField.text);
    }

    public void OnMapHeightInputFieldChanged()
    {
        mapGenerator.mapHeight = Convert.ToInt32(mapHeightInputField.text);
    }

    public void OnMapScaleXInputFieldChanged()
    {
        mapGenerator.meshScaleX = Convert.ToInt32(mapScaleXInputField.text);
    }

    public void OnMapScaleZInputFieldChanged()
    {
        mapGenerator.meshScaleZ = Convert.ToInt32(mapScaleZInputField.text);
    }

    public void OnMeshHeightMultiplierInputFieldChanged()
    {
        mapGenerator.meshHeightMultiplier = Convert.ToInt32(meshHeightMultiplierInputField.text);
    }

    public void OnLevelOfDetailSliderChanged()
    {
        mapGenerator.levelOfDetail = (int)levelOfDetailSlider.value;
        levelOfDetailSliderValue.text = mapGenerator.levelOfDetail.ToString();
        if (mapGenerator.levelOfDetail == 5 && mapGenerator.mapHeight == 505 && mapGenerator.mapWidth == 505)
        {
            mapGenerator.levelOfDetail = 6;
        }
        else if (mapGenerator.levelOfDetail == 5 && mapGenerator.mapHeight == 1021 && mapGenerator.mapWidth == 1021)
        {
            mapGenerator.levelOfDetail = 6;
        }
        else if (mapGenerator.levelOfDetail == 5 && mapGenerator.mapHeight == 2041 && mapGenerator.mapWidth == 2041)
        {
            mapGenerator.levelOfDetail = 6;
        }
        else if (mapGenerator.levelOfDetail == 5 && mapGenerator.mapHeight == 4081 && mapGenerator.mapWidth == 4081)
        {
            mapGenerator.levelOfDetail = 6;
        }
    }

    public void OnOffsetXInputFieldChanged()
    {
        mapGenerator.offset.x = Convert.ToInt32(offsetXInputField.text);
    }

    public void OnOffsetYInputFieldChanged()
    {
        mapGenerator.offset.y = Convert.ToInt32(offsetYInputField.text);

    }

    public void OnSeedInputFieldChanged()
    {
        mapGenerator.seed = Convert.ToInt32(seedInputField.text);
    }

    public void OnNoiseSliderChanged()
    {
        mapGenerator.noiseScale = noiseScaleSlider.value;
        noiseScaleSliderValue.text = mapGenerator.noiseScale.ToString("0.0");

    }

    public void OnOctaveSliderChanged()
    {
        mapGenerator.octaves = (int)octaveScaleSlider.value;
        octaveScaleSliderValue.text = mapGenerator.octaves.ToString();
    }

    public void OnLacunaritySliderChanged()
    {
        mapGenerator.lacunarity = lacunarityScaleSlider.value;
        lacunarityScaleSliderValue.text = mapGenerator.lacunarity.ToString("0.00");
    }

    public void OnPersistanceSliderChanged()
    {
        mapGenerator.persistance = persistanceScaleSlider.value;
        persistanceScaleSliderValue.text = mapGenerator.persistance.ToString("0.00");
    }

    public void OnGenerateMeshButtonPressed()
    {
        
        GetComponent<MapGenerator>().DrawMapInEditor();
    }

    public void OnMeshExportButtonPressed()
    {

        MeshFilter meshFilter = mesh.GetComponent<MeshFilter>();
        if (meshFilter != null)
        {
            Mesh mesh = meshFilter.sharedMesh;
            //saves it in the temp folder
            string exportToDesktopPath = Path.Combine(Path.GetTempPath(), "Exported Mesh.obj");

            MeshToObjExporter.ExportMesh(mesh, exportToDesktopPath);
        }

        

    }

    public void OnExitButtonPressed()
    {
        Application.Quit();
    }

    public void OnAutoUpdateChecked()
    {

        if (autoUpdateCheckBox.isOn)
        {

            GetComponent<MapGenerator>().DrawMapInEditor();

        }
        
    }


    public void OnShowMeshButtonPressed()
    {

        mapGenerator.drawMode = MapGenerator.DrawMode.Mesh;
        mapGenerator.useFalloff = false;

        mesh.SetActive(true);
        plane.SetActive(false);
        
        showMeshButton.GetComponent<Image>().color = Color.white;
        showMeshButtonText.GetComponent<TextMeshProUGUI>().color = Color.black;

        showColorMapButton.GetComponent<Image>().color = Color.black;
        showColorMapButtonText.GetComponent<TextMeshProUGUI>().color = Color.white;

        showNoiseMapButton.GetComponent<Image>().color = Color.black;
        showNoiseMapButtonText.GetComponent<TextMeshProUGUI>().color = Color.white;

        showFalloffMapButton.GetComponent<Image>().color = Color.black;
        showFalloffMapButtonText.GetComponent<TextMeshProUGUI>().color = Color.white;

    }

    public void OnShowColorMapButtonPressed()
    {
        mapGenerator.drawMode = MapGenerator.DrawMode.ColourMap;

        mapGenerator.useFalloff = false;

        mesh.SetActive(false);
        plane.SetActive(true);

        showMeshButton.GetComponent<Image>().color = Color.black;
        showMeshButtonText.GetComponent<TextMeshProUGUI>().color = Color.white;

        showColorMapButton.GetComponent<Image>().color = Color.white;
        showColorMapButtonText.GetComponent<TextMeshProUGUI>().color = Color.black;

        showNoiseMapButton.GetComponent<Image>().color = Color.black;
        showNoiseMapButtonText.GetComponent<TextMeshProUGUI>().color = Color.white;

        showFalloffMapButton.GetComponent<Image>().color = Color.black;
        showFalloffMapButtonText.GetComponent<TextMeshProUGUI>().color = Color.white;

    }

    public void OnShowNoiseButtonPressed()
    {
        mapGenerator.drawMode = MapGenerator.DrawMode.NoiseMap;

        mapGenerator.useFalloff = false;

        mesh.SetActive(false);
        plane.SetActive(true);

        showMeshButton.GetComponent<Image>().color = Color.black;
        showMeshButtonText.GetComponent<TextMeshProUGUI>().color = Color.white;

        showColorMapButton.GetComponent<Image>().color = Color.black;
        showColorMapButtonText.GetComponent<TextMeshProUGUI>().color = Color.white;

        showNoiseMapButton.GetComponent<Image>().color = Color.white;
        showNoiseMapButtonText.GetComponent<TextMeshProUGUI>().color = Color.black;

        showFalloffMapButton.GetComponent<Image>().color = Color.black;
        showFalloffMapButtonText.GetComponent<TextMeshProUGUI>().color = Color.white;

    }

    public void OnShowFalloffButtonPressed()
    {
        mapGenerator.drawMode = MapGenerator.DrawMode.Mesh;

        mapGenerator.useFalloff = true;
        mesh.SetActive(true);
        plane.SetActive(false);

        showMeshButton.GetComponent<Image>().color = Color.black;
        showMeshButtonText.GetComponent<TextMeshProUGUI>().color = Color.white;

        showColorMapButton.GetComponent<Image>().color = Color.black;
        showColorMapButtonText.GetComponent<TextMeshProUGUI>().color = Color.white;

        showNoiseMapButton.GetComponent<Image>().color = Color.black;
        showNoiseMapButtonText.GetComponent<TextMeshProUGUI>().color = Color.white;

        showFalloffMapButton.GetComponent<Image>().color = Color.white;
        showFalloffMapButtonText.GetComponent<TextMeshProUGUI>().color = Color.black;

    }

    public void OnViewSnapButtonPressed()
    {
        mainCamera.GetComponent<Camera>().transform.SetPositionAndRotation(new Vector3(0, 692, -813), new Quaternion(0.391712397f,0,0,0.920087755f));

    }

    public void OnViewInfoPanelButtonPressed()
    {
            infoPanel.SetActive(true);

    }
    public void OnInfoPanelCloseButtonPressed()
    {
        infoPanel.SetActive(false);
    }

    public void OnDeepWaterLevelSliderChanged()
    {
        mapGenerator.regions[0].height = deepWaterLevelSlider.value;
        deepWaterLevelValue.text = mapGenerator.regions[0].height.ToString("0.00");
    }

    public void OnWaterLevelSliderChanged()
    {
        mapGenerator.regions[1].height = waterLevelSlider.value;
        waterLevelValue.text = mapGenerator.regions[1].height.ToString("0.00");
    }

    public void OnSandLevelSliderChanged()
    {
        mapGenerator.regions[2].height = sandLevelSlider.value;
        sandLevelValue.text = mapGenerator.regions[2].height.ToString("0.00");
    }

    public void OnGrassLevelSliderChanged()
    {
        mapGenerator.regions[3].height = grassLevelSlider.value;
        grassLevelValue.text = mapGenerator.regions[3].height.ToString("0.00");
    }

    public void OnRockLevelSliderChanged()
    {
        mapGenerator.regions[4].height = rockLevelSlider.value;
        rockLevelValue.text = mapGenerator.regions[4].height.ToString("0.00");
    }

    public void OnSnowLevelSliderChanged()
    {
        mapGenerator.regions[5].height = snowLevelSlider.value;
        snowLevelValue.text = mapGenerator.regions[5].height.ToString("0.00");
    }

    public void OnDropDownOptionChanged()
    {
        switch (dropdown.value)
        {
            case 0:
                mapGenerator.mapWidth = 121;
                mapGenerator.mapHeight = 121;
                mapWidtAndHeightInputPanel.SetActive(false);

                break;
            case 1:
                mapGenerator.mapWidth = 241;
                mapGenerator.mapHeight = 241;
                mapWidtAndHeightInputPanel.SetActive(false);


                break;
            case 2:
                mapGenerator.mapWidth = 505;
                mapGenerator.mapHeight = 505;
                mapWidtAndHeightInputPanel.SetActive(false);


                break;
            case 3:
                mapGenerator.mapWidth = 1021;
                mapGenerator.mapHeight = 1021;
                mapWidtAndHeightInputPanel.SetActive(false);

                break;
            case 4:
                mapGenerator.mapWidth = 2041;
                mapGenerator.mapHeight = 2041;
                mapWidtAndHeightInputPanel.SetActive(false);

                break;
            case 5:
                mapGenerator.mapWidth = 4081;
                mapGenerator.mapHeight = 4081;
                mapWidtAndHeightInputPanel.SetActive(false);

                break;
            case 6:
                mapWidtAndHeightInputPanel.SetActive(true);
                break;
            
        }

    }
}
