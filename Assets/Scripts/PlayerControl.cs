using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed = 2;
    public Rigidbody2D rb;
    public float jumpAmount = 100;
    bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(x * speed, rb.velocity.y);


        //bool player_jump = Input.GetKeyDown(KeyCode.Space);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            //rb.AddForce(new Vector2(rb.velocity.x, jumpAmount));
            isGrounded = false;
        }
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
     
                if (collision.gameObject.CompareTag("Base") || collision.gameObject.CompareTag("Ground"))
                {
                    isGrounded = true;
                }

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Triggered!");
        if (other.gameObject.CompareTag("Ground"))
        {


            if (GetComponent<SpriteRenderer>().color != other.GetComponent<SpriteRenderer>().color)
            {

                Debug.Log("Triggered, different color: " + other.name);
                other.GetComponent<Collider2D>().enabled = false;
            }
            else
            {
                Debug.Log("Triggered, same color: " + other.name);
                other.GetComponent<Collider2D>().enabled = true;
            }
        }

    }



    //void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        isGrounded = false;
    //    }
    //}

}
