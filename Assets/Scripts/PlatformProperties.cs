using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ColorEntity platformColorEntity = GetComponent<ColorEntity>();
        ColorEntity playerColorEntity = collision.collider.GetComponent<ColorEntity>();
  
        if (playerColorEntity.currentColor != platformColorEntity.currentColor)
        {

            Debug.Log("collides true!");
            GetComponent<BoxCollider2D>().enabled = false;
        
        }
    }




}
