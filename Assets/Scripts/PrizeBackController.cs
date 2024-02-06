using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrizeBackController : MonoBehaviour
{
    // Declara el diccionario para mapear strings a sprites
    private Dictionary<string, Sprite> prizeSpriteDictionary = new Dictionary<string, Sprite>();

    public Sprite bearSprite;
    public Sprite flowerSprite;
    public Sprite smileSprite;

    public string ticketScene;
    public float timeToLoadScene;

    // Start is called before the first frame update
    void Start()
    {
        InitializePrizeSpriteDictionary();

        string prizeKey = PlayerPrefs.GetString("PrizeGotName");
        Debug.Log(prizeKey);
        Sprite assignedSprite = GetPrizeSprite(prizeKey);

        if (assignedSprite != null)
        {
            Debug.Log("Changing Sprite...");
            GetComponent<SpriteRenderer>().sprite = assignedSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializePrizeSpriteDictionary()
    {
        prizeSpriteDictionary.Add("bear", bearSprite);
        prizeSpriteDictionary.Add("flower", flowerSprite);
        prizeSpriteDictionary.Add("smile", smileSprite);
        prizeSpriteDictionary.Add("bear (1)", bearSprite);
        prizeSpriteDictionary.Add("flower (1)", flowerSprite);
        prizeSpriteDictionary.Add("smile (1)", smileSprite);
    }

    // Method to get a sprite based on the provided key
    public Sprite GetPrizeSprite(string key)
    {
        if (prizeSpriteDictionary.ContainsKey(key))
        {
            Debug.Log("Selecting Sprite...");
            return prizeSpriteDictionary[key];
        }
        else
        {
            Debug.LogError("Key '" + key + "' not found in the dictionary.");
            return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Loading....");
        Invoke("LoadScene", timeToLoadScene);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(ticketScene);
    }

}
