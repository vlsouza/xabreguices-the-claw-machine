using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeMenuController : MonoBehaviour
{
    private static PrizeMenuController instance;

    public Dictionary<string, GameObject> prizeDictionary = new Dictionary<string, GameObject>();
    public string prizeGotName;

    public GameObject bearGameObject;
    public GameObject flowerGameObject;
    public GameObject smileGameObject;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializePrizeSpriteDictionary();
        string prizeKey = PlayerPrefs.GetString("PrizeGotName");
        EnableGameObject(prizeKey);
    }

    private void InitializePrizeSpriteDictionary()
    {
        prizeDictionary.Add("bear", bearGameObject);
        prizeDictionary.Add("flower", flowerGameObject);
        prizeDictionary.Add("smile", smileGameObject);
        prizeDictionary.Add("bear (1)", bearGameObject);
        prizeDictionary.Add("flower (1)", flowerGameObject);
        prizeDictionary.Add("smile (1)", smileGameObject);
    }

    // Method to get a sprite based on the provided key
    public void EnableGameObject(string key)
    {
        if (prizeDictionary.ContainsKey(key))
        {
            Debug.Log("Selecting item...");

            prizeDictionary[key].SetActive(true);
        }
        else
        {
            Debug.LogError("Key '" + key + "' not found in the dictionary.");
        }
    }
}
