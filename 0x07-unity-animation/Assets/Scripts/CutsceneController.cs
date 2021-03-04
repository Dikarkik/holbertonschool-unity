using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject timerCanvas;
    public PlayerController playerController;
    
    public void EndOfIntro()
    {
        mainCamera.SetActive(true);
        timerCanvas.SetActive(true);
        playerController.enabled = true;
        this.gameObject.SetActive(false);
    }
}
