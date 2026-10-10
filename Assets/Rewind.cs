
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rewind : MonoBehaviour
{
    public List<PlayerPositions> PlayerPos = new List<PlayerPositions>();
    public  Rigidbody2D rb;
    public Renderer self;

    private bool rewinding = false;

    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Space))
        {
            self.material.color = Color.lightBlue;
            Do();
        }

        if (rewinding == true)
            return;

        if (Input.GetKey(KeyCode.Space))
        {
            self.material.color = Color.blue;
            rewinds();
        }
        
    }


    public void Do()
    {
        if (rewinding)
            return;

        StartCoroutine(RewindCo());
    }    
    
    public void rewinds()
    {
        PlayerPos.Add(new PlayerPositions
        {
            position = transform.position,
            velocity = rb.linearVelocity
        });
        
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


[System.Serializable]

public class PlayerPositions
{
    public Vector2 position;
    public Vector2 velocity;
}