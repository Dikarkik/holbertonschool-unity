using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScene : MonoBehaviour
{
	private void Start()
	{
		PlayerPrefs.SetString("SavedScene", SceneManager.GetActiveScene().name);
	}
}
