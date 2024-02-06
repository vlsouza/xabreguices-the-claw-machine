using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrizeDoorController : MonoBehaviour
{
    public string prizeScene;

    public float timeToLoadScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Prize"))
        {
            Debug.Log("Got prize!");
            PlayerPrefs.SetString("PrizeGotName", collision.gameObject.name);
            PlayerPrefs.Save();
            Invoke("LoadScene", timeToLoadScene);
            Debug.Log("Loading Game");
        }

    }

    void LoadScene()
    {
        // Carrega a nova cena
        SceneManager.LoadScene(prizeScene);
    }
}
