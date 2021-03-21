using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYAxis;
    public Slider bgmSlider;
    public Slider sfxSlider;
    public AudioMixer audioMixer;
    
	private void Start()
	{
		invertYAxis.isOn = PlayerPrefs.GetInt("invertYAxis") == 1 ? true : false;
        bgmSlider.value = PlayerPrefs.GetFloat("bgmSlider", 0);
        sfxSlider.value = PlayerPrefs.GetFloat("sfxSlider", 0);
        
        ApplyAudio();
    }
	private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            Back();
    }

    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("SavedScene"));
    }

    public void Apply()
    {
        var invert = invertYAxis.isOn ? 1 : 0;
        PlayerPrefs.SetInt("invertYAxis", invert);
        ApplyAudio();
        Back();
    }
    
    private void ApplyAudio()
    {
        PlayerPrefs.SetFloat("bgmSlider", bgmSlider.value);
        PlayerPrefs.SetFloat("sfxSlider", sfxSlider.value);
        
        var muteBGM = bgmSlider.value < -19.9f ? 80 : 0;
        var muteSFX = sfxSlider.value < -19.9f ? 80 : 0;

        // apply audio volume
        audioMixer.SetFloat("bgmVol", bgmSlider.value - muteBGM);
        audioMixer.SetFloat("uiVol", sfxSlider.value - muteSFX);
        audioMixer.SetFloat("ambienceVol", (sfxSlider.value + 5) - muteSFX);
        audioMixer.SetFloat("runningVol", (sfxSlider.value - 22) - muteSFX);
        audioMixer.SetFloat("landingVol", (sfxSlider.value + 2) - muteSFX);
    }
}
