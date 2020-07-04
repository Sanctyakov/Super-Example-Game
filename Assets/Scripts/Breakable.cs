using UnityEngine;

public class Breakable : MonoBehaviour
{
    private GameController gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void OnCollisionEnter2D(Collision2D other) //Destroy parent object if hit, and notify the game controller.
    {
        gameController.BreakableDown();

        Destroy(transform.parent.gameObject);
    }
}