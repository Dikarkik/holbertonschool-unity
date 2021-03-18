using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Next()
    {
        var currentScene = SceneManager.GetActiveScene().name;

        switch(currentScene)
        {
            case "Level01":
                SceneManager.LoadScene("Level02");
                break;
            case "Level02":
                SceneManager.LoadScene("Level03");
                break;
            default:
                SceneManager.LoadScene("MainMenu");
                break;
        }
    }
}
