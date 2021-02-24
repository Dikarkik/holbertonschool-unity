using UnityEngine;

public class WinTrigger : MonoBehaviour
{
	public GameObject winCanvas;

	private void OnTriggerEnter(Collider other)
	{
		if(other.name == "Player")
		{
			other.GetComponent<Timer>().StopTimer();
			winCanvas.SetActive(true);
			FindObjectOfType<Timer>().Win();
		}
	}
}
