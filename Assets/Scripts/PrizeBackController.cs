using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrizeBackController : MonoBehaviour
{
    public string nextScene;
    public float timeToLoadScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Loading....");
        AudioManager.instance.PlaySFX(3);
        Invoke("LoadScene", timeToLoadScene);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(nextScene);
    }

}
