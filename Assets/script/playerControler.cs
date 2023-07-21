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

    public GameObject kinfeL;
    public GameObject kinfeR;
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
        if (playerData.durum == 1)
        {
            playerHaraket();
        }
        else if (playerData.durum == -1)
        {
            botYonKontrol();
            BotHareket();
            botPlayerControl();
        }
        else if (playerData.durum > 7)
        {
            playerData.durum--;
            playerData.knifeTransform.position += new Vector3(0.1f, 0, 0);

        }
        else if (playerData.durum > 2)
        {
            playerData.durum--;
            playerData.knifeTransform.position -= new Vector3(0.1f, 0, 0);
        }
        else if (playerData.durum == 2)
        {
            playerData.knifeTransform.gameObject.SetActive(false);
            playerData.durum = 1;
        }


    }

    void botPlayerControl()
    {
        if (((transform.position.x + (playerData.botDurum * 5) > playerData.playerGame.transform.position.x) &&
            (transform.position.x < playerData.playerGame.transform.position.x)) ||
            ((transform.position.x + (playerData.botDurum * 5) < playerData.playerGame.transform.position.x) &&
            (transform.position.x > playerData.playerGame.transform.position.x)))
            {
            print("öldün");
        }
    }

    void botYonKontrol()//botun x sýnýrlarýnda dönemsini saðlar
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

    void BotHareket()//botun x eksenininde hereketini saðlar
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

    void playerHaraket()//playerin harektini saðlar
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, 0);
            playerData.yon = 1;
            playerData.botDurum = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, 0);
            playerData.yon = -1;
            playerData.botDurum = -1;
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

    public void botDead()
    {
        playerData.durum = -10;
        animator.SetInteger("yon", 0);
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        print("vurdu");
        GetComponent<FadeOutEffect>().play();
    }

    private void knifeAnim()
    {
        if (playerData.botDurum == 1)
            playerData.knifeTransform = kinfeL.transform;
        else if (playerData.botDurum == -1)
            playerData.knifeTransform = kinfeR.transform;
        print("alýnan silah");
        playerData.knifeTransform.gameObject.SetActive(true);
        playerData.durum = 12;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.F) && playerData.durum == 1 && other.GetComponent<PlayerData>().durum != -10)
        { 
            other.GetComponent<playerControler>().botDead();
            knifeAnim();
        }

    }
    private void OnCollisionStay2D(Collision2D collision) // zemine deyme kontrol
    {
        if (collision.gameObject.CompareTag("zemin"))
        {
            jump = false;
        }
    }
}