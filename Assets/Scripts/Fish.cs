using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movespeed = 10f;
    public Vector2 movment;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movment * movespeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Hook" && gameObject.tag != "Shark")
        {
            collision.gameObject.GetComponent<Hook>().catchFish(gameObject);
        }
        if (collision.gameObject.tag == "Hook" && gameObject.tag == "Shark" && collision.gameObject.GetComponent<Hook>().catchfishing == true)
        {
            collision.gameObject.GetComponent<Hook>().catchfishing = false;
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Fish" && gameObject.tag == "Shark")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
