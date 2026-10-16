using UnityEngine;

public class move : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jumpf;
    public bool jump = true;

    void Update()
    {
        movement();
    }

    void movement()
    {
        float x = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
            x = -speed;
        if (Input.GetKey(KeyCode.RightArrow))
            x = speed;
        if (Input.GetKeyDown(KeyCode.UpArrow) && jump == true)
        {
            rb.AddForce(Vector2.up * jumpf);
            jump = false;
        }

        rb.linearVelocity = new Vector2(x,rb.linearVelocityY);
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

