using UnityEngine;

public class WinTrigger : MonoBehaviour
{
	public GameObject winCanvas;

	private void OnTriggerEnter(Collider other)
	{
		if (other.name != "Player") return;
		
		var timer = other.GetComponent<Timer>();
		timer.StopTimer();
		winCanvas.SetActive(true);
		timer.Win();
	}
}
