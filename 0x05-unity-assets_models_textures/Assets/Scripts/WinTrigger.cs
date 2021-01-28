using UnityEngine;

public class WinTrigger : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
        if(other.name == "Player")
            other.GetComponent<Timer>().StopTimer();
	}
}
