using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisherManScript : MonoBehaviour
{
    public GameObject progressBar;
    public GameObject menuPanel;

    private Rigidbody2D rb;
    private Vector2 manMovement;
    private float manSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bird")
        {
            //progressBar.GetComponent<SliderScript>().slider.value = 100;
            menuPanel.SetActive(true);
            progressBar.GetComponent<SliderScript>().gameOver = true;
            Time.timeScale = 0;

        }
    }

    public void jump()
    {
        rb.GetComponent<Transform>().position = new Vector2(-0.424f, 4.5f);
        Invoke("jumpBack", 1);
    }

    public void jumpBack()
    {
        rb.GetComponent<Transform>().position = new Vector2(-0.424f, 3.589f);
    }
}
