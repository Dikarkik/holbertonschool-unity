using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsAudio : MonoBehaviour
{
    private bool isGrass = true;
    public AudioSource playerAudioSource;
    public AudioClip footsteps_running_grass;
    public AudioClip footsteps_running_rock;

    private void Step()
    {
        if (isGrass)
            playerAudioSource.PlayOneShot(footsteps_running_grass);
        else
            playerAudioSource.PlayOneShot(footsteps_running_rock);

    }
    
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit.gameObject.name);

        if (hit.gameObject.CompareTag("Grass")) //Change if we want incline
            isGrass = true;
        else
            isGrass = false;
    }
}
