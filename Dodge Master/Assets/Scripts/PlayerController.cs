using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public TMP_Text ScoreTxt;
    public GameObject panelGameOver;

    private Rigidbody2D rb;
    private Animator anim;
    private enum State {idle, running, jumping, falling}
    private State state = State.idle;

    bool isGrounded = false;
    bool isAlive = true;
    int Score;

    // Start is called before the first frame update
    private void Awake()
    {
        Score = 0;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {

        }
        float hDirection = Input.GetAxis("Horizontal");

        //! Jika menekan key A maka rigidbody bergerak ke kiri.
        // if(Input.GetKey(KeyCode.A)) -> switched key to using unity Input GetAxis.
        if (hDirection < 0)
        {
            //! bergerak ke kiri dengan speed 5.
            rb.velocity = new Vector2(-5, rb.velocity.y);

            //! flip sprite menghadap kiri saat menekan A.
            transform.localScale = new Vector2(-1, 1);
        }

        //! Jika menekan key D maka rigidbody bergerak ke kanan.
        // else if (Input.GetKey(KeyCode.D)) -> switched key to using unity Input GetAxis.
        else if (hDirection > 0)
        {
            //! bergerak ke kanan dengan speed 5.
            rb.velocity = new Vector2(5, rb.velocity.y);

            //! flip sprite menghadap kanan saat menekan D.
            transform.localScale = new Vector2(1, 1);
        } 
        else
        {
            //
        }

        //! Jika menekan key spasi maka rigidbody melompat keatas.
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, 10f);
                state = State.jumping;
                isGrounded = false;
            }
        }

        VelocityState();
        anim.SetInteger("state", (int) state);
    }

    private void VelocityState()
    {
        if (state == State.jumping)
        {
            if (rb.velocity.y < .1f)
            {
                //! Falling
                state = State.falling;
            }
        }

        else if (state == State.falling)
        {
            if (isGrounded == true)
            {
                state = State.idle;
            }
        }

        else if ((rb.velocity.y) < -4f)
        {
            state = State.falling;
        }

        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            //! Moving
            state = State.running;
        }

        else
        {
            //! Idling
            state = State.idle;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //! Mendeteksi posisi karakter jika telah menyentuh tanah setelah melompat (agar melompat hanya 1x tiap klik key Space)
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        }

        //! Skor +10 setiap menyentuh objek Cherry
        if (collision.gameObject.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            Score += 10;
            ScoreTxt.text = "Score: " + Score.ToString();
        }

        //! Game Over setiap menabrak musuh sebagai objek rintangan (Elang / Tikus / Duri)
        if (collision.gameObject.CompareTag("Enemies"))
        {
            isAlive = false;
            panelGameOver.SetActive(true);
        }

        //! Naik ke Level 2 setiap mencapai Portal berupa Rumah di ujung kanan Map
        if (collision.gameObject.CompareTag("Rumah"))
        {
            SceneManager.LoadScene("EndGame");
        }
    }
}
