using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;

    public GameManager gameManager;

    public int health;

    public float jumpForce;

    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        // Implement Jumping using SPACE Key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }

        // Implement Game Over
        if (health <= 0)
        {
            gameManager.GameOver();
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        // Check collision with floor to make transition back to walk animation
        if (collision.gameObject.tag == "Floor")
        {
            animator.SetBool("isJumping", false);
        }
        
        // Check if Player Hits an Obstacle
        if (collision.gameObject.tag == "Obstacle")
        {
            health --;
        }
    }
}
