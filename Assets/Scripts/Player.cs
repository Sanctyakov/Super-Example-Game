using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed; //Set within the inspector.

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //Arrows or WASD.

        Vector2 movement = new Vector2(moveHorizontal, 0.0f);

        rb.velocity = movement * speed;
    }
}
