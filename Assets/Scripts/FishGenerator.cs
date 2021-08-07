using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    public GameObject fishPrefab;
    public GameObject sharkPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(createFish());
        StartCoroutine(createShark());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator createFish() 
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 3f));
        GameObject fish = Instantiate(fishPrefab);
        bool rightfish = Random.Range(0, 2) == 1;

        float y = Random.Range(-4f, 1.5f);
        float x;
        if (rightfish) 
        {
            x = 5;
            fish.GetComponent<Fish>().movment.x = Random.Range(-0.3f,-0.1f);
            fish.GetComponent<Transform>().Rotate(0f, 180f, 0f);
        }
        else
        {
            x = -5;
            fish.GetComponent<Fish>().movment.x =Random.Range(0.3f,0.1f);
        }
        fish.GetComponent<Transform>().position = new Vector3(x, y, 1);
        StartCoroutine(createFish());
    }
    private IEnumerator createShark()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 3f));
        GameObject shark = Instantiate(sharkPrefab);
        bool rightfish = Random.Range(0, 2) == 1;

        float y = Random.Range(-4f, 1.5f);
        float x;
        if (rightfish)
        {
            x = 5;
            shark.GetComponent<Fish>().movment.x = Random.Range(-0.3f, -0.1f);
            shark.GetComponent<Transform>().Rotate(0f, 180f, 0f);
        }
        else
        {
            x = -5;
            shark.GetComponent<Fish>().movment.x = Random.Range(0.3f, 0.1f);
        }
        shark.GetComponent<Transform>().position = new Vector3(x, y, 1);
        StartCoroutine(createShark());
    }
}
