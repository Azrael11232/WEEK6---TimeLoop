
using UnityEngine;

public class moving : MonoBehaviour
{
    public Rigidbody2D rb;
    public float range;
    public float speed;

    private Vector2 startPosition;
    private Vector2 targetPosition;

    void Start()
    {
        startPosition = rb.position;
        targetPosition = GetRandomPosition();
    }

    void Update()
    {
        move();
    }

    Vector2 GetRandomPosition()
    {
        return new Vector2(
            Random.Range(startPosition.x - range, startPosition.x + range),
            startPosition.y
        );
    }

    void move()
    {
        rb.position = Vector2.MoveTowards(
            rb.position,
            targetPosition,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(rb.position, targetPosition) < 0.1f)
        {
            targetPosition = GetRandomPosition();
        }
    }
}
