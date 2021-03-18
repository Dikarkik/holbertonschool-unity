using System;
using UnityEngine;
using UnityEngine.Audio;

public class StepsAudio : MonoBehaviour
{
    private bool isGrass = true;
    public AudioSource playerAudioSource;
    public AudioClip footsteps_running_grass;
    public AudioClip footsteps_running_rock;
    public AudioClip footsteps_landing_grass;
    public AudioClip footsteps_landing_rock;
    
    public AudioMixer audioMixer;
    private AudioMixerGroup runningMixerGroup;
    private AudioMixerGroup landingMixerGroup;


    private void Start()
    {
        runningMixerGroup = audioMixer.FindMatchingGroups("Running")[0];
        landingMixerGroup = audioMixer.FindMatchingGroups("Landing")[0];
    }

    private void Step()
    {
        if (playerAudioSource.outputAudioMixerGroup.name != "Running")
            playerAudioSource.outputAudioMixerGroup = runningMixerGroup;
        
        if (isGrass)
            playerAudioSource.PlayOneShot(footsteps_running_grass);
        else
            playerAudioSource.PlayOneShot(footsteps_running_rock);
    }
    
    private void Landing()
    {
        if (playerAudioSource.outputAudioMixerGroup.name != "Landing")
            playerAudioSource.outputAudioMixerGroup = landingMixerGroup;
        
        if (isGrass)
            playerAudioSource.PlayOneShot(footsteps_landing_grass);
        else
            playerAudioSource.PlayOneShot(footsteps_landing_rock);
    }
    
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Grass"))
            isGrass = true;
        else
            isGrass = false;
    }
}
