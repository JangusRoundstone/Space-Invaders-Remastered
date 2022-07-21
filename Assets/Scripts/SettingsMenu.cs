using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions(); //clear default option and start on a clean slate
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " X " + resolutions[i].height; //resolution display format
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    /**
     *Sets the game resolution as per the players' choice
     *@param[in] resolutionIndex The index position of resolution assigned in the array
     */


    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
    /**
     *Allows the player to adjust the game background music after converting to log value
     *@param[in] volume The volume input into the audio mixer
     */

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }

    /**
     *Allows the player to adjust the game graphics
     *@param[in] qualityIndex The index position of resolution assigned in the array
     */

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    /**
     *Allows the player to play in fullscreen mode or windowed mode
     *@param[in] isFullScreen The boolean value to set game to fullscreen mode when true and 
     *windowed mode when false
     */

    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
