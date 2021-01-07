using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    Vector3 pos = new Vector3(22, 26, 7);

    void Update()
    {
        pos.x = player.transform.position.x;
        pos.z = player.transform.position.z - 9;

        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
    }
}
