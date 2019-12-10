using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Resolution[] resolutions;

    public Dropdown screenResolutions;
    private void Start()
    {
        resolutions = Screen.resolutions;

        screenResolutions.ClearOptions();

        List<string> resolutionOptions = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string resolutionChoice = resolutions[i].width + " x " + resolutions[i].height;
            resolutionOptions.Add(resolutionChoice);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        screenResolutions.AddOptions(resolutionOptions);
        screenResolutions.value = currentResolutionIndex;
        screenResolutions.RefreshShownValue();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("FullMap");
    }

    public GameObject startMenu;
    public GameObject optionsMenu;
    public void Options()
    {
        startMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    
    public void Back()
    {
        optionsMenu.SetActive(false);
        startMenu.SetActive(true);

    }
    public void QuitGame()
    {
        Debug.Log("Has Quit");
        Application.Quit();
    }

    public AudioMixer audioVolume;

    public void SetVolume ( float volumeValue)
    {
        Debug.Log(volumeValue);
        audioVolume.SetFloat("volume", volumeValue);
    }

    public void SetFullscreen ( bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
