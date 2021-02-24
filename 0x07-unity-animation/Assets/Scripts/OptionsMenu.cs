using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYAxis;

	private void Start()
	{
		invertYAxis.isOn = PlayerPrefs.GetInt("invertYAxis") == 1 ? true : false;
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
        Back();
    }
}
