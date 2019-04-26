using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 3.0f;
    public float jumpForce = 4.0f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public bool isJumping;
    public Animator animate;
    public Vector2 jumping = new Vector2(0,1);


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //animate = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //animate.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));


    }
    void FixedUpdate()
    {

        moveCharacter(movement);
        jumpCharacter();
        

    }

    void moveCharacter(Vector2 direction)
    {
        rb.velocity = direction * speed;

    }

    void jumpCharacter()
    {
        if(Input.GetKey(KeyCode.Space) && !isJumping)
        {
            isJumping = true;

            rb.velocity = jumping * jumpForce;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            rb.velocity = Vector2.zero;
        }
    }

}
