using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonScript : MonoBehaviour
{
    public GameObject menu;

    public void Restart(GameObject menu)
    {
        SceneManager.LoadScene("SampleScene");
        menu.SetActive(false);
        Time.timeScale = 1;
    }
}
