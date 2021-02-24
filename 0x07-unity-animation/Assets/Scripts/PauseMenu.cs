using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;

	private void Update()
	{
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!pauseCanvas.activeSelf)
                Pause();
            else 
                Resume();
        }
    }

	public void Pause()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        pauseCanvas.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
    }

    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        Resume();
        SceneManager.LoadScene("Options");
    }
}
