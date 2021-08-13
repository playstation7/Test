using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{

    private int offset = 0;
    public bool catchfishing;

    public GameObject fishOnHook;
    public GameObject progressBar;
    public GameObject AirBalls;
    public bool isPaused = false;
    private Vector3 worldPosition;



    // Start is called before the first frame update

    float speed = 1.5f;
    // Update is called once per frame
    void Update()
    {
        //Checing User's device
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        }
        else if (Input.touchCount > 0 && !progressBar.GetComponent<SliderScript>().gameOver && !isPaused)
        {
            Touch touch = Input.GetTouch(0);
            worldPosition = Camera.main.ScreenToWorldPoint(touch.position);
        }

        //Seting hook's position 
        if (worldPosition.y * speed < 4f && worldPosition.y * speed > -4 && !progressBar.GetComponent<SliderScript>().gameOver && !isPaused)
        {
            transform.position = new Vector3(transform.position.x, worldPosition.y * speed, 1);
            
        }
        else if(!progressBar.GetComponent<SliderScript>().gameOver && !isPaused)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(worldPosition.y * speed, -4f, 4f), 1) ;
        }

        //Catching fish 
        if (worldPosition.y * speed > 3.7f + offset && catchfishing)
        {
            catchfishing = false;
            fishOnHook.SetActive(false);
            SliderScript script = progressBar.GetComponent<SliderScript>();
            script.increaseProgressBar(10);
            AirBalls.SetActive(false);
            AirBalls.SetActive(true);
        }
    }
    
    public void catchFish(GameObject fish) 
    {
        if (!catchfishing) 
        {
            fishOnHook.SetActive(true);
            catchfishing = true;
            Destroy(fish);
        }
    }

    
}

