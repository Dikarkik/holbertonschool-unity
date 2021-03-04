using UnityEngine;

public class TriggerToDetectFalling : MonoBehaviour
{
    public PlayerController playerControllerScript;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
            playerControllerScript.FallingAnim();
    }
}
