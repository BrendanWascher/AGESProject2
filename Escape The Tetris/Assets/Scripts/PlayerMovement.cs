using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D myRigidBody;

    [SerializeField]
    float movementSpeed = 1;

    [SerializeField]
    float jumpStrength = 10;

    [SerializeField]
    Transform groundDetectPoint;

    [SerializeField]
    Transform ceilingDetectPoint;

    [SerializeField]
    float groundDetectRadius = .2f;

    [SerializeField]
    LayerMask whatCountsAsGround;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip deathClip;

    [SerializeField]
    AudioClip jumpClip;

    [SerializeField]
    private string thisScene = "Level1";

    public static bool isOnGround;

    private bool shouldJump = false;
    private bool hasBeenHit = false;
    private float horizontalInput;

    private Vector2 jumpForce;

    private bool facingRight = true;

    private Animator anim;


    // Use this for initialization
    void Start()
    {
        //shouldJump = true;
        audioSource = GetComponent<AudioSource>();
        myRigidBody = GetComponent<Rigidbody2D>();
        jumpForce = new Vector2(0, jumpStrength);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasBeenHit)
        {
            GetMovementInput();
            GetJumpInput();
            UpDateIsOnGround();
            CrushCheck();
        }
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        //anim.SetFloat("Speed", Mathf.Abs(move));
        //anim.SetFloat("vSpeed", Mathf.Abs(verticalMove));

        HandleMovement(move);
        HandleJump();
    }

    private IEnumerator PlayerDeath()
    {

        while (audioSource.isPlaying)
        {
            yield return null;
        }

        SceneManager.LoadScene(thisScene);
        yield return null;
    }

    private void CrushCheck()
    {
        RaycastHit2D hit;
        if (hit = Physics2D.Raycast(ceilingDetectPoint.position, Vector2.up, .01f))
        {
            if (!hasBeenHit)
            {
                if (hit.transform.tag == "TetrisBlock")
                {
                    audioSource.clip = deathClip;
                    audioSource.Play();
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    StartCoroutine(PlayerDeath());
                    hasBeenHit = true;
                }
            }
        }
    }

    private void HorizontalFlip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void GetMovementInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void GetJumpInput()
    {
        if (Input.GetButtonDown("Jump") && (isOnGround))
        {
            shouldJump = true;
        }
    }

    private void UpDateIsOnGround()
    {
        Collider2D[] groundObjects = Physics2D.OverlapCircleAll(groundDetectPoint.position, groundDetectRadius, whatCountsAsGround);
        isOnGround = groundObjects.Length > 0;
    }

    private void HandleJump()
    {
        if (shouldJump)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpStrength);
            audioSource.clip = jumpClip;
            audioSource.Play();
            myRigidBody.AddForce(jumpForce);
            isOnGround = false;
            shouldJump = false;
        }
    }

    private void HandleMovement(float move)
    {
        myRigidBody.velocity = new Vector2(horizontalInput * movementSpeed, myRigidBody.velocity.y);

        if (move > 0 && !facingRight)
            HorizontalFlip();
        else if (move < 0 && facingRight)
            HorizontalFlip();

    }
}
