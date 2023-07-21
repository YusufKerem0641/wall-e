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
        if (playerData.durum != -1)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !jump)
            {
                jumpFonction();
            }
        }
    }
    void FixedUpdate()
    {
        if (playerData.durum != -1)
        {
            playerHaraket();
        }
        else if (playerData.durum == -1)
        {
            botYonKontrol();
            BotHareket();
        }


    }

    void botYonKontrol()
    {
        if (transform.position.x < playerData.botMinX)
        {
            playerData.botDurum = 1;
        }
        else if (transform.position.x > playerData.botMaxX)
        {
            playerData.botDurum = -1;
        }
    }

    void BotHareket()
    {
        if (playerData.botDurum == 1)
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, 0);
        }
        else if (playerData.botDurum == -1)
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, 0);
        }
        animator.SetInteger("yon", playerData.botDurum);
    }

    void playerHaraket()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, 0);
            playerData.yon = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, 0);
            playerData.yon = -1;
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            playerData.yon = 0;
        }
        animator.SetInteger("yon", playerData.yon);
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