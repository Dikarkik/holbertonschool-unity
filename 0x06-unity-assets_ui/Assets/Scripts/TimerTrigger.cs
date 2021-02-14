using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
	private void OnTriggerExit(Collider other)
	{
        if(other.name == "Player")
            other.GetComponent<Timer>().enabled = true;
	}
}
