using UnityEngine;

public class CylinderMove : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float x = Input.GetAxis("Horizontal"); // A/D
        float z = Input.GetAxis("Vertical");   // W/S

        Vector3 move = new Vector3(x, 0, z);

        transform.Translate(move * speed * Time.deltaTime, Space.World);
    }
}