using UnityEngine;

public class move : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public bool jump = true;
    private Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        moveInput = Vector2.zero;

        if (Input.GetKey(KeyCode.W) && jump == transform)
        {
            moveInput *= Vector2.up;
            jump = false;
        }

        if (Input.GetKey(KeyCode.S))
            moveInput += Vector2.down;

        if (Input.GetKey(KeyCode.A))
            moveInput += Vector2.left;

        if (Input.GetKey(KeyCode.D))
            moveInput += Vector2.right;

        moveInput = moveInput.normalized;

        Vector2 newPosition = rb.position + moveInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        jump = true;
    }
}

public class PlayerPosition
{
    public Vector2 position;
    public Vector2 velocity;
}

