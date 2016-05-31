
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class PauseMenu : MonoBehaviour 
{
	//GUI gameobjects
	public GameObject UIParrent;
	public GameObject PauseMenuGroup;
	public GameObject OptionsMenuGroup;

	public GameObject GeneralGroup;
	public GameObject GraphicsGroup;
	public GameObject SoundGroup;
	public GameObject ControlsGroup;

	public GameObject ResolutionX;
	public GameObject ResolutionY;
	public GameObject ResolutionHZ;

    public GameObject TestersPanel;

	public GameObject Character;

	public GameObject FogToggler;

	public GameObject MainCam;
	public GameObject NaturalBloomAndLensToggler;
	public GameObject SunShaftsToggler;
	public GameObject RainWeatherToggler;
	public GameObject RainPartic;

	public bool ShowPM;
	public bool ShowOM;

	public Terrain TestmapTerrain;

	void Start () 
	{
		//Debug.Log (QualitySettings.GetQualityLevel());
	}
	

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (ShowPM == true)
			{
				HidePM();
				HideOM();
			}
			else if (ShowPM == false)
			{
				DrawPM();
			}
		}
		if(ShowPM == true)
		{
			PauseMenuGroup.SetActive (true);
		}
		else
		{
			PauseMenuGroup.SetActive (false);
		}
		if(ShowOM == true)
		{
			OptionsMenuGroup.SetActive (true);
		}
		else
		{
			OptionsMenuGroup.SetActive (false);
		}

		if(ShowOM == false)
		{
			GeneralGroup.SetActive (false);
			GraphicsGroup.SetActive (false);
			SoundGroup.SetActive (false);
			ControlsGroup.SetActive (false);
		}

		Toggle FT = FogToggler.transform.gameObject.GetComponent<Toggle>();
		if (FT.isOn == true) 
		{
			RenderSettings.fog = true;
		}
		else
		{
			RenderSettings.fog = false;
		}
		SunShafts SS = MainCam.transform.gameObject.GetComponent<SunShafts>();
		Toggle SST = SunShaftsToggler.transform.gameObject.GetComponent<Toggle>();
		if (SST.isOn == true) 
		{
			SS.enabled = true;
		}
		else
		{
			SS.enabled = false;
		}
		SENaturalBloomAndDirtyLens NBAL = MainCam.transform.gameObject.GetComponent<SENaturalBloomAndDirtyLens>();
		Toggle NBALT = NaturalBloomAndLensToggler.transform.gameObject.GetComponent<Toggle>();
		if (NBALT.isOn == true)
		{
			NBAL.enabled = true;
		}
		else
		{
			NBAL.enabled = false;
		}

		

	}

	void HidePM()
	{
		ShowPM = false;
	}

	void DrawPM()
	{
		ShowPM = true;
	}

	void HideOM()
	{
		ShowOM = false;
	}
	
	void DrawOM()
	{
		ShowOM = true;
	}

	void ShowGeneral()
	{
		GeneralGroup.SetActive (true);
		GraphicsGroup.SetActive (false);
		SoundGroup.SetActive (false);
		ControlsGroup.SetActive (false);
	}

	void ShowGraphics()
	{
		GeneralGroup.SetActive (false);
		GraphicsGroup.SetActive (true);
		SoundGroup.SetActive (false);
		ControlsGroup.SetActive (false);
	}

	void ShowSound()
	{
		GeneralGroup.SetActive (false);
		GraphicsGroup.SetActive (false);
		SoundGroup.SetActive (true);
		ControlsGroup.SetActive (false);
	}

	void ShowControls()
	{
		GeneralGroup.SetActive (false);
		GraphicsGroup.SetActive (false);
		SoundGroup.SetActive (false);
		ControlsGroup.SetActive (true);
	}
	void SetToLow()
	{
		QualitySettings.SetQualityLevel(0,true);
		TestmapTerrain.treeBillboardDistance = 100;
		TestmapTerrain.detailObjectDistance = 90;
	}
	void SetToMedium()
	{
		QualitySettings.SetQualityLevel(1,true);
		TestmapTerrain.treeBillboardDistance = 800;
		TestmapTerrain.detailObjectDistance = 180;
	}
	void SetToHigh()
	{
		QualitySettings.SetQualityLevel(2,true);
		TestmapTerrain.treeBillboardDistance = 2000;
		TestmapTerrain.detailObjectDistance = 250;
	}
	void ToggleFullscreen(bool TF)
	{
		Screen.fullScreen = TF;
	}
	void SetRes()
	{
		string rx = ResolutionX.GetComponent<UnityEngine.UI.Text> ().text;
		string ry = ResolutionY.GetComponent<UnityEngine.UI.Text> ().text;
		string rhz = ResolutionY.GetComponent<UnityEngine.UI.Text> ().text;
		Screen.SetResolution (int.Parse(rx), int.Parse(ry), true, int.Parse(rhz));
	}
    void ToggleTestersPanel()
    {
        if (TestersPanel.active == true)
        {
            TestersPanel.SetActive(false);
        }
        else
        {
            TestersPanel.SetActive(true);
        }
    }
	void QuitTestersPanel()
	{
		TestersPanel.SetActive(false);
	}
	void QuitProject()
	{
		Application.Quit ();
	}

}
