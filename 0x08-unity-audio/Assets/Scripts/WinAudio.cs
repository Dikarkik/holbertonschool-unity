using UnityEngine;

public class WinAudio : MonoBehaviour
{
    public AudioSource backgoundAudioSource;

    public AudioSource winAudioSource;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player") return;
        
        backgoundAudioSource.Stop();
        winAudioSource.enabled = true;
    }
}
