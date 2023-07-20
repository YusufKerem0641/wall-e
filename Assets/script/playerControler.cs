using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontal;
    private float speed;
    private bool jump = false;
    private float jumpForce;
    private PlayerData playerData;
    private Animator animator;
    void Start()
    {
        playerData = GetComponent<PlayerData>();
        jumpForce = playerData.jumpForce;
        speed = playerData.speed;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !jump)
        {
            jumpFonction();
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        { 
            rb.velocity = new Vector3(speed, rb.velocity.y, 0);
            animator.SetInteger("yon", 1);
        }
        else if (Input.GetKey(KeyCode.A))
        { 
            rb.velocity = new Vector3(-speed, rb.velocity.y, 0);
            animator.SetInteger("yon", -1);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
            animator.SetInteger("yon", 0);
        }
    }

    public void jumpFonction() // zýplama fonksiyonu
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        jump = true;
    }


    private void OnCollisionEnter2D(Collision2D collision) // zemine deyme kontrol
    {
        if (collision.gameObject.CompareTag("zemin"))
        {
            jump = false;
            Debug.Log("Çarpýþma algýlandý!");
        }
    }
}