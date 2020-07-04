using UnityEngine;

public class Ball : MonoBehaviour //This script moves things in a random diagonal direction according to the speed entered in the inspector (negative will move downwards, positive upwards).
{
    public float speed; //Set within the inspector.

    public GameController gameController;

    private float hSpeed, vSpeed; //For storing horizontal and vertical speed.

    private Rigidbody2D rb;

    void Start() //We will not concern ourselves with mass in this game, so we'll modify velocity directly instead of using AddForce.
    {
        rb = GetComponent<Rigidbody2D>();

        int randomDirection = Random.Range(0, 1) * 2 - 1;

        hSpeed = speed * randomDirection; //Go left or right, but always up.
        vSpeed = speed;
    }

    public void GameStart() //Begin moving.
    {
        Velocity();
    }

    private void OnCollisionEnter2D (Collision2D other) //Reflects speed depending on which surface is hit.
    {
        if (other.gameObject.tag == "Horizontal")
        {
            vSpeed = -vSpeed;

            Velocity();
        }
        else if (other.gameObject.tag == "Vertical")
        {
            hSpeed = -hSpeed;

            Velocity();
        }
    }

    private void OnTriggerExit2D (Collider2D collider) //If the ball goes through the floor, the game is over.
    {
        if (collider.gameObject.tag == "Floor")
        {
            Destroy(gameObject);

            gameController.GameOver();
        }
    }

    private void Velocity()
    {
        rb.velocity = transform.right * hSpeed + transform.up * vSpeed;
    }
}
