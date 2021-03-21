using UnityEngine;
using UnityEngine.Audio;

public class LoadAudio : MonoBehaviour
{
    public AudioMixer audioMixer;

    void Start()
    {
        var bgmVol = PlayerPrefs.GetFloat("bgmSlider", 0);
        var sfxVol = PlayerPrefs.GetFloat("sfxSlider", 0);
        
        var muteBGM = bgmVol < -19.9f ? 80 : 0;
        var muteSFX = sfxVol < -19.9f ? 80 : 0;

        // apply audio volume
        audioMixer.SetFloat("bgmVol", bgmVol - muteBGM);
        audioMixer.SetFloat("uiVol", sfxVol - muteSFX);
        audioMixer.SetFloat("ambienceVol", (sfxVol + 5) - muteSFX);
        audioMixer.SetFloat("runningVol", (sfxVol - 22) - muteSFX);
        audioMixer.SetFloat("landingVol", (sfxVol + 2) - muteSFX);
    }
}
