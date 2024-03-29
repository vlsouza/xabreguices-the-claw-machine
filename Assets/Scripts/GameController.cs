using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Dictionary<string, GameObject> prizeDictionary = new Dictionary<string, GameObject>();
    public string prizeGotName;

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

        string prizeKey = PlayerPrefs.GetString("PrizeGotName");
        EnableGameObject(prizeKey);

        //if (assignedSprite != null)
        //{
        //    Debug.Log("Changing Sprite...");
        //    GetComponent<SpriteRenderer>().sprite = assignedSprite;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to get a sprite based on the provided key
    public void EnableGameObject(string key)
    {
        if (prizeDictionary.ContainsKey(key))
        {
            Debug.Log("Selecting Sprite...");

            prizeDictionary[key].SetActive(true);
        }
        else
        {
            Debug.LogError("Key '" + key + "' not found in the dictionary.");
        }
    }
}
