using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject breakable, gameOverScreen, gameStartScreen; //A prefab to instantiate + interface screens.

    public Ball ball;

    public Transform breakableParent; //Grid layout group to instantiate breakables.

    public int breakableAmount; //Keeps count of breakables.

    void Start() //Instantiate as many breakables as set in inspector.
    {
        for (int i = 0; i < breakableAmount; i++)
        {
            Instantiate(breakable, breakableParent);
        }
    }

    void Update()
    {
        if (gameOverScreen.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.R)) //Restart the game upon R key down.
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (gameStartScreen.activeSelf)
        {
            if (Input.anyKeyDown) //Start the game upon key down.
            {
                GameStart();
            }
        }
    }

    private void GameStart()
    {
        breakableParent.GetComponent<GridLayoutGroup>().enabled = false;

        ball.GameStart();

        gameStartScreen.SetActive(false);
    }

    public void BreakableDown() //Called whenever a breakable is destroyed.
    {
        if (breakableAmount > 1)
        {
            breakableAmount--;
        }
        else
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
