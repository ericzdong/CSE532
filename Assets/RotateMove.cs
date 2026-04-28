using UnityEngine;

public class RotateMove : MonoBehaviour
{
    public float moveSpeed = 2f;        // movement speed
    public float roamRadius = 10f;      // how far NPC can roam
    public float changeTime = 3f;       // seconds before changing direction
    public bool bobbing = false;        // hover effect
    public float bobHeight = 0.3f;
    public float bobSpeed = 2f;

    private Vector3 startPos;
    private Vector3 direction;
    private float timer;

    void Start()
    {
        startPos = transform.position;
        PickNewDirection();
    }

    void Update()
    {
        timer += Time.deltaTime;

        // change direction every few seconds
        if (timer >= changeTime)
        {
            PickNewDirection();
            timer = 0f;
        }

        // move NPC
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);

        // keep NPC inside roam area
        if (Vector3.Distance(startPos, transform.position) > roamRadius)
        {
            transform.position = startPos;
            PickNewDirection();
        }

        // optional hover effect
        if (bobbing)
        {
            float newY = startPos.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }

    void PickNewDirection()
    {
        direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }
}