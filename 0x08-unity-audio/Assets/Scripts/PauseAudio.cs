using UnityEngine;
using UnityEngine.Audio;

public class PauseAudio : MonoBehaviour
{
    public AudioMixerSnapshot normal;
    public AudioMixerSnapshot paused;

    public void Pause()
    {
        paused.TransitionTo(0f);
    }
    
    public void Normal()
    {
        normal.TransitionTo(0f);
    }
}
