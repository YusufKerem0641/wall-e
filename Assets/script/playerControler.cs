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
    void Start()
    {
        playerData = GetComponent<PlayerData>();
        jumpForce = playerData.jumpForce;
        speed = playerData.speed;
        rb = GetComponent<Rigidbody2D>();
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
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(horizontal * speed, rb.velocity.y, 0);

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