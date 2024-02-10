using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    public Color playerColor;
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

        playerColor = GetComponent<SpriteRenderer>().color;

        if (collision.gameObject.CompareTag("Star"))
        {
            // Change the ball's color to that of the star
            GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;

            // Optionally, destroy the star object after collecting it
            Destroy(collision.gameObject);

            // Re-enable collision with platforms of the same color as the player

            playerColor = GetComponent<SpriteRenderer>().color;

            GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");

            int activeLayer = LayerMask.NameToLayer("Active Platform");
            int inactiveLayer = LayerMask.NameToLayer("Inactive Platform");


            foreach (GameObject platform in platforms)
            {
                Collider2D collider = platform.GetComponent<Collider2D>();

                if (collider != null)
                {
                    Color platformColor = collider.GetComponent<SpriteRenderer>().color;
                    if(playerColor == platformColor)
                    {
                        collider.enabled = true;
                        collider.gameObject.layer = activeLayer;
                    }
                    else
                    {
                        collider.enabled = false;
                        collider.gameObject.layer = inactiveLayer;
                    }
                    
                }
            }


        }

    }
}
