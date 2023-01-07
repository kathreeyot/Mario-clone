using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{







    Rigidbody2D rb;
    public int speed;
    [Header("Jump System")]
    [SerializeField] float jumpTime;
    [SerializeField] int jumpPower;
    [SerializeField] float fallMultiplier;
    [SerializeField] float jumpMutiplier;
    bool doublejump;

    public Transform groundCheck;
    public LayerMask groundLayer;
    Vector2 vecGravity;

    bool isJumping;
    float jumpCounter;
    public Animator animator;
    Vector2 vecMove;

    bool isGrounded;

    // Start is called before the first frame update
    //

    //โค๊ดเริ่มต้นเอาrigid body มา//
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vecGravity = new Vector2(0, -Physics2D.gravity.y);

    }
    
    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(vecMove.x));
        //update move speed//

    }

    public void Jump(InputAction.CallbackContext value)
    {
        //โค๊ด กระโดด เเละ ground check//

        if (value.started && Grounded())
        {
            AudioManager.instance.Play("FirstJump");
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isJumping = true;
            jumpCounter = 0;
            doublejump = true;
        }
        
        else if (value.started &&  doublejump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower * 0.8f);
            doublejump = false;
            AudioManager.instance.Play("SecondJump");
        }
        if (value.canceled)
        {
            isJumping = false;
            jumpCounter = 0;

            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
            }
        }
        
    }

    public void Movement(InputAction.CallbackContext value)
    {
         //อ่านค่า vector 2 //
        vecMove = value.ReadValue<Vector2>();

    }
    public void FixedUpdate()
    {
        flip();
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.6f, 0.3f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        rb.velocity = new Vector2(vecMove.x * speed, rb.velocity.y);
        if (rb.velocity.y   < 0)
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }
        if (rb.velocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;


            if (jumpCounter > jumpTime) isJumping = false;



            float t = jumpCounter / jumpTime;

            float currentJumpM = jumpMutiplier;
            if (t > 0.5f)
            {
                currentJumpM = jumpMutiplier * (1 - t);
            }
            rb.velocity += vecGravity * currentJumpM * Time.deltaTime;
        }
    }

    
    bool Grounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.6f, 0.3f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }

    void flip()
    {
        if (vecMove.x < 0) transform.localScale = new Vector3(-1, 1, 1);
        if (vecMove.x > 0) transform.localScale = new Vector3(1, 1, 1);
    }
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PowerUp")
        {
            Destroy(other.gameObject);
            GetComponent<SpriteRenderer>().color = Color.yellow;
           
            jumpPower = jumpPower+ 2;



            StartCoroutine(ResetPower());
        }

    }
    private IEnumerator ResetPower()
    {
        yield return new WaitForSeconds(5);
        jumpPower = jumpPower - 2;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}