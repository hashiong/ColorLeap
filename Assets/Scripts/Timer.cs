using System.Collections;
using System. Collections. Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{

    [SerializeField] TMP_Text timerText;
    [SerializeField] float time = 1;

    bool isRunning = false;
    TimeSpan timespan;
    public GameObject EndScene;
    public GameObject WinScene;



    // Start is called before the first frame update
    void Start()
    {
        isRunning = true;
        EndScene.SetActive(false);
        //GameObject endScene = GameObject.FindGameObjectWithTag("GameOver");
        //endScene.SetActive(false);

    }

    // Update is called once per frame
    private void Update()
    {
        
        if (isRunning)
        {
          time -= Time.deltaTime;
            
        }
    

        if(time < 0)
        {
            bool isActive = gameObject.activeInHierarchy;

            if (isActive)
            {
                isRunning = false;
                return;
            }

            time = 0;
            isRunning = false;
            // Find the GameObject with a specific tag (replace "OtherObjectTag" with the actual tag of the otherObject)
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            //player.SetActive(false);

            // Get the script component from the otherObject
            PlayerController2 playerControlScriptComponent = player.GetComponent<PlayerController2>();
            if (playerControlScriptComponent != null)
            {
                playerControlScriptComponent.enabled = false;
            }

            Rigidbody2D rd2DScriptComponent = player.GetComponent<Rigidbody2D>();
            if (rd2DScriptComponent != null)
            {
                rd2DScriptComponent.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;

            }

            EndScene.SetActive(true);


        }
        

        timespan = TimeSpan.FromSeconds(time);

        timerText.text = string.Format("{0:D2}:{1:d2}:{2:D2}", timespan.Hours, timespan.Minutes, timespan.Seconds);
    }

    public void stopRunning()
    {
        isRunning = false;
    }


}
