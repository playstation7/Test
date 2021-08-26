using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public bool catchfishing;
    public GameObject fishOnHook;
    public GameObject progressBar;
    public int catchedFishCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);


        if (worldPosition.y < 4f && worldPosition.y > -4)
            {
                transform.position = new Vector3(transform.position.x, worldPosition.y, 1);
                if (worldPosition.y > 3.5f && catchfishing)
                {
                    catchedFishCount++;
                    catchfishing = false;
                    fishOnHook.SetActive(false);
                    SliderScript script = progressBar.GetComponent<SliderScript>();
                    script.increaseProgressBar(10);
                }
            }
        }
        else if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 toucPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if (toucPosition.y < 4f && toucPosition.y > -4)
            {
                transform.position = new Vector3(transform.position.x, toucPosition.y, 1);
                if (toucPosition.y > 3.5f && catchfishing)
                {
                    catchfishing = false;
                    fishOnHook.SetActive(false);
                    
                }

            }
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

