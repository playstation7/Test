using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject Timer;
    public Slider slider;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(progressBar());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator progressBar() 
    {
        yield return new WaitForSeconds(0.10f);
        if (Timer.GetComponent<Timer>().timer > 30f)
        {
            slider.value -= 0.5f;
        } else if (Timer.GetComponent<Timer>().timer > 60f)
        {
            slider.value -= 0.7f;
        } else
        {
            slider.value -= 0.3f;
        }
        if (slider.value == 0)
        {
            //slider.value = 100;
            menuPanel.SetActive(true);
            gameOver = true;
            Time.timeScale = 0;
        }
        StartCoroutine(progressBar());
    }

    public void increaseProgressBar(int points) 
    {
        slider.value += (float)points;
    }

}
