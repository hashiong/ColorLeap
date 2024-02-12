using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{

    public GameObject PassedScene;
    // Start is called before the first frame update
    void Start()
    {
        PassedScene.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {


        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
      
            // Get the script component from the otherObject
            PlayerController2 playerControlScriptComponent = other.GetComponent<PlayerController2>();
            if (playerControlScriptComponent != null)
            {
                playerControlScriptComponent.enabled = false;
            }

            Rigidbody2D rd2DScriptComponent = other.GetComponent<Rigidbody2D>();
            if (rd2DScriptComponent != null)
            {
                rd2DScriptComponent.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;

            }

            PassedScene.SetActive(true);
        }

    }

}
