using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Text winLoseText;
    public Image winLoseBG;

    // movement and rotation
    public float speed;
    Rigidbody rb;
    Vector3 forceDirection;
    Vector3 rotationDirection;
    public VariableJoystick variableJoystick; // Android imput

    void Start()
    {
        rb = GetComponent<Rigidbody>();

#if UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX
        variableJoystick.gameObject.SetActive(false);
#endif
    }

    void SetScoreText() => scoreText.text = $"Score: {score}";

	void SetHealthText() => healthText.text = $"Health: {health}";

    void DisplayYouWin()
    {
        winLoseText.text = $"You Win!";
        winLoseText.color = Color.black;
        winLoseBG.color = Color.green;
        winLoseBG.transform.gameObject.SetActive(true);
    }

    void DisplayYouLose()
    {
        winLoseText.text = $"Game Over!";
        winLoseText.color = Color.white;
        winLoseBG.color = Color.red;
        winLoseBG.transform.gameObject.SetActive(true);
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    void FixedUpdate()
    {
        // input
#if UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX
        forceDirection.x = Input.GetAxis("Horizontal");
        forceDirection.z = Input.GetAxis("Vertical");
        rotationDirection.x = Input.GetAxis("Vertical");
        rotationDirection.z = -Input.GetAxis("Horizontal");
#endif
#if UNITY_ANDROID
        forceDirection.x = variableJoystick.Horizontal;
        forceDirection.z = variableJoystick.Vertical;
        rotationDirection.x = variableJoystick.Vertical;
        rotationDirection.z = -variableJoystick.Horizontal;
#endif

        // movement and rotation
        rb.AddForce(forceDirection * speed * Time.deltaTime);
        transform.Rotate(rotationDirection * (speed * 3) * Time.deltaTime);
    }

	void Update()
	{
        if(health == 0)
        {
            //Debug.Log("Game Over!");
            StartCoroutine(LoadScene(3));
            DisplayYouLose();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }

	void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Pickup":
                score++;
                Destroy(other.gameObject);
                //Debug.Log($"Score: {score}");
                SetScoreText();
                break;
            case "Trap":
                health--;
                SetHealthText();
                //Debug.Log($"Health: {health}");
                break;
            case "Goal":
                //Debug.Log("You win!");
                StartCoroutine(LoadScene(3));
                DisplayYouWin();
            break;
        }
    }
}
