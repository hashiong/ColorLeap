using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            // Change the ball's color to that of the star
            GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;

            // Optionally, destroy the star object after collecting it
            Destroy(collision.gameObject);
        }

    }
}
