using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public float range = 100f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        // Shoot ray from camera forward
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Debug.Log("Hit: " + hit.collider.name);

            // ONLY destroy enemies
            if (hit.collider.CompareTag("enemy"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}