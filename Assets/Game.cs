
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject player;
    public GameObject goal;

    void Update()
    {
        if (player == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (goal == null)
        {
            Time.timeScale = 0;
        }
    }
}

