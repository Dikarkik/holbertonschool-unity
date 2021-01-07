using UnityEngine;

public class Brake : MonoBehaviour
{
    public Rigidbody rb;
    public SpriteRenderer spriteRenderer;
    Vector3 pos = new Vector3(0, 0.28f, 0);

    void Update()
    {
        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && rb.velocity.magnitude > 0.1f)
        {
            pos.x = rb.transform.position.x;
            pos.z = rb.transform.position.z;
            transform.position = pos;
            spriteRenderer.enabled = true;
        }
        else
            spriteRenderer.enabled = false;
    }
}
