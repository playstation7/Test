using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGenerator : MonoBehaviour
{
    public GameObject birdPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(createBird());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator createBird()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 13f));
        GameObject bird = Instantiate(birdPrefab);

        float y = 3.562f;
        float x;

        x = 5;
        bird.GetComponent<Bird>().birdMovement.x = -0.3f;

        bird.GetComponent<Transform>().position = new Vector3(x, y, 1);
        StartCoroutine(createBird());
    }
}