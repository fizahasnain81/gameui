 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player3 : MonoBehaviour
{
    public bool isGameOver = false;

    public int score = 0; // Current score
    //public int highScore; // High score
    public UI snakeUI1;
    public bool isPaused;
    public GameObject door;
    public Transform groundCheckCollider;
    const float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    [SerializeField] float jumpPower = 500;
    [SerializeField] float speed = 2;
    Animator animator;
    public Rigidbody2D rb;
    bool facingRight = true;
    bool isRunning;
    bool isMoving = false; // Flag to track movement sound
    float horizontalValue;
    float runSpeedModifier = 2f;
    public bool isGrounded = true;
    bool jump;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        isPaused = false;
        if (door != null)
        {
            door.SetActive(false); // Ensure door is hidden initially
        }
        snakeUI1.UpdateScore(score);
    }
    public void PauseGame1()
    {
        // SoundManager.PlaySound(SoundManager.Sound.ButtonClick);
        Time.timeScale = 0;
        isPaused = true;
        snakeUI1.PausePanelShowHide1();

    }
    public void Resume1()
    {
        // SoundManager.PlaySound(SoundManager.Sound.ButtonClick);
        Time.timeScale = 1;
        isPaused = false;
        snakeUI1.PausePanelShowHide1();
    }
    void Update()
    {
        if (isGameOver)
        {
            Time.timeScale = 0;
            isPaused = true;
            // Stop all movement or input processing
           // return;
        }
        horizontalValue = Input.GetAxisRaw("Horizontal");

        // Play/stop movement sound based on horizontal input
        if (horizontalValue != 0 && !isMoving)
        {
            AudioManager34.instance.PlaySFX("playermoving");
            isMoving = true;
        }
        else if (horizontalValue == 0 && isMoving)
        {
            AudioManager34.instance.StopSFX("playermoving");
            isMoving = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetTrigger("jumps");
            AudioManager34.instance.PlaySFX("jumping");
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jump = false;
            animator.SetTrigger("jump2");
            AudioManager34.instance.PlaySFX("landing");
        }
    }

    private void FixedUpdate()
    {
        /*if (isGameOver)
        {
            // Ensure the Rigidbody stops
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            return;
        }*/
        GroundCheck();
        Move(horizontalValue, jump);
    }

    void GroundCheck()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
        }
    }

    private void Move(float dir, bool jumpflag)
    {
        if (isGrounded && jumpflag)
        {
            isGrounded = false;
            jumpflag = false;
            rb.AddForce(new Vector2(0f, jumpPower));
        }

        float xVal = dir * speed * 100 * Time.fixedDeltaTime;
        if (isRunning)
        {
            xVal *= runSpeedModifier;
        }
        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        rb.velocity = targetVelocity;

        if (facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }
        else if (!facingRight && dir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "e")
        {

            Debug.Log($"{name} Triggered");
            AudioManager34.instance.PlaySFX("frog");
            FindObjectOfType<HealthBar>().LoseHealth(25);
            score = score + 1; // Reset score
            snakeUI1.UpdateScore(score);
            //score = 0; // Reset score
            //snakeUI1.UpdateScore(score);
            //snakeUI1.ShowLosePanel1();
            // AudioManager34.instance.PlaySFX("jumping");
            //animator.SetTrigger("jump2");
        }
        else if (collision.tag == "p")
        {
            Debug.Log($"{name} Triggered");
            //bool b = FindObjectOfType<HealthBar>().increaseHealth(25);
            score = score+1; // Reset score
            snakeUI1.UpdateScore(score);
           // if ((b == false))
           // {
                Destroy(collision.gameObject);
                AudioManager34.instance.PlaySFX("cherry");
                //AudioManager34.instance.PlaySFX("landing");
                //
           // }
            // Destroy(collision.gameObject);
        }
        else if (collision.tag == "health1")
        {
            Debug.Log($"{name} Triggered");
            bool b = FindObjectOfType<HealthBar>().increaseHealth(25);
            score = score + 1; // Reset score
            snakeUI1.UpdateScore(score);
            if ((b == false))
            {
                Destroy(collision.gameObject);
                AudioManager34.instance.PlaySFX("cherry");
                //AudioManager34.instance.PlaySFX("landing");
                //
            }
            // Destroy(collision.gameObject);
        }
        else if (collision.tag == "q")
        {
            Debug.Log($"{name} Triggered");
            int h3 = FindObjectOfType<key>().losekey();
            score = score + 1; // Reset score
            snakeUI1.UpdateScore(score);
            Destroy(collision.gameObject);
            AudioManager34.instance.PlaySFX("key");
            if (h3 == 0)
            {
                door.SetActive(true); // Show door when all keys are collected
                AudioManager34.instance.PlaySFX("door");
                snakeUI1.VictoryPanel1();
                Time.timeScale = 0;
                isPaused = true;
                // animator.SetTrigger("jump2");
            }

            // Destroy(collision.gameObject);
        }
    }
}
