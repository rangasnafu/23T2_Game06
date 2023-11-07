using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;

    //variables for flipping the sprite
    private bool isFacingRight = true;

    //components needed for the player controller
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public float deathDelay = 2f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get horizontal input from the player
        horizontal = Input.GetAxisRaw("Horizontal");

        //if the player presses the jump button and is grounded, jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);


        }

        //if the player releases the jump button while still jumping, reduce jump height 
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        //flip the player sprite if moving in the opposite direction
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("SideCollision"))
    //    {
    //        PlayerLives playerLives = GetComponent<PlayerLives>();

    //        playerLives.LoseALife();

    //        animator.SetTrigger("Death");

    //        rb.simulated = false;

    //        soundManager.PlayerDeathSound();

    //        StartCoroutine(ReloadSceneAfterDelay(deathDelay));
    //    }
    //}

    //private IEnumerator ReloadSceneAfterDelay(float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}
}
