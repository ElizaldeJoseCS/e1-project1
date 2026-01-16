using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    float movementX;
    float movementY;
    Rigidbody2D rb;
    bool isGrounded = false;

    [SerializeField] float speed = 10f;
    [SerializeField] float jumpPower = 100f;


    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        movementX = v.x;
        movementY = v.y;
        Debug.Log("Movement X = " + movementX);
        Debug.Log("Movement Y = " + movementY);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        // float movementDistanceX = movementX * speed * Time.deltaTime;
        // float movementDistanceY = movementY * speed * Time.deltaTime;
        // transform.position = new Vector2(transform.position.x + movementDistanceX, transform.position.y + movementDistanceY);
        rb.linearVelocity = new Vector2(movementX * speed, rb.linearVelocity.y);


        if (movementY > 0 && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpPower));
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
