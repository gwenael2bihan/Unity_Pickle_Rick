using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;

    public float moveSpeed = 40f;
    public bool isGrounded = false;
    bool jump = false;
    float timer;
    
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Movement();
        timer += Time.deltaTime;
        if (timer > 0.3) {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            timer = 0;
        }
    }

    private void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy") {
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("Death");

        }

        if (other.gameObject.tag == "Projectile") {
            Debug.Log("COLLISION Player: ", other.gameObject);

            Destroy(other.gameObject);
            
         //   gameObject.GetComponent<Renderer>().material.color = Color.red;

       }

    }

    void Movement() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            FindObjectOfType<AudioManager>().Play("Run");
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            FindObjectOfType<AudioManager>().Stop("Run");
        }
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }

    public void OnLanding() {
        animator.SetBool("isJumping", false);
    }

    void Jump() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            jump = true;
            animator.SetBool("isJumping", true);
            FindObjectOfType<AudioManager>().Play("Jump");
            //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 7f), ForceMode2D.Impulse);
        }

    }
}