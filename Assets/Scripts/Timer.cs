using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public float timer = 0;
    public GameObject progressBar;
    public Text timeCount;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!progressBar.GetComponent<SliderScript>().gameOver)
        {
            timer += Time.deltaTime;
            timeCount.text = timer.ToString("0");
        }
    }
}
