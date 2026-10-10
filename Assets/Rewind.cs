
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewind : MonoBehaviour
{
    public List<PlayerPosition> PlayerPos = new List<PlayerPosition>();
    public  Rigidbody2D rb;
    private bool rewinding = false;

    void Update()
    {
        if (rewinding == true)
            return;

        PlayerPos.Add(new PlayerPosition
        {
            position = transform.position,
            velocity = rb.linearVelocity
        });
    }

    public void Do()
    {
        if (rewinding)
            return;

        StartCoroutine(RewindCo());
    }

    public IEnumerator RewindCo()
    {
        rb.simulated = false;
        rewinding = true;

        for (int i = PlayerPos.Count - 1; i >= 0; i--)
        {
            transform.position = PlayerPos[i].position;
            rb.linearVelocity = PlayerPos[i].velocity;

            yield return null;
        }

        rb.simulated = true;
        rewinding = false;

        PlayerPos.Clear();
    }
}
