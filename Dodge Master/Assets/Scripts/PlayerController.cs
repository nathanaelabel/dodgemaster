using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hDirection = Input.GetAxis("Horizontal");

        // Jika menekan key A maka rigidbody bergerak ke kiri.
        // if(Input.GetKey(KeyCode.A))

        // switched key to using unity Input GetAxis.
        if (hDirection < 0)
        {
            // bergerak ke kiri dengan speed 5.
            rb.velocity = new Vector2(-5, rb.velocity.y);

            // flip sprite menghadap kiri saat menekan A.
            transform.localScale = new Vector2(-1, 1);

            // setting animator saat player berlari
            anim.SetBool("running", true);
        }
        // Jika menekan key D maka rigidbody bergerak ke kanan.
        // else if (Input.GetKey(KeyCode.D))

        // switched key to using unity Input GetAxis.
        else if (hDirection > 0)
        {
            // bergerak ke kanan dengan speed 5.
            rb.velocity = new Vector2(5, rb.velocity.y);

            // flip sprite menghadap kanan saat menekan D.
            transform.localScale = new Vector2(1, 1);

            // setting animator saat player berlari
            anim.SetBool("running", true);
        } 
        else
        {
            // setting animator saat player idle
            anim.SetBool("running", true);
        }

        // Jika menekan key spasi maka rigidbody melompat keatas.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }

    }
}
