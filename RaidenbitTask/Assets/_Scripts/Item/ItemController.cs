using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    #region Public Variables

    [Header("Message of the Day")] 
    // Reference to the Message of the Day Text
    // which will be updated based on JSON parsed
    public TextMeshProUGUI messageOfTheDayText;

    [Header("Item")] 
    // Reference to the Prefab to be Instantiated based on 
    // JSON parsed
    public GameObject itemPrefab;

    [Header("Items Parent")] 
    public Transform itemsParent;

    [Header("JSON Data File")] 
    // Using JSON Data File as a TextAsset will allow
    // for easy reading
    public TextAsset JSONDataFile;

    // Reference to store ImagePath of the Items
    [NonSerialized] public string ImagePath;

    #endregion

    #region Private Variables

    // A reference to store all Items after deserializing JSON
    private ItemCollection _itemCollection;

    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        // Load JSON From Data File at the Start of the App
        LoadJSONFromFile();
        
        // Set Fields other than Item List
        SetMainFieldsFromData();
        
        // Then Generate Item Prefabs
        GenerateItemPrefabsFromData();
    }

    /// <summary>
    /// Loads JSON from a TextAsset file
    /// </summary>
    private void LoadJSONFromFile()
    {
        // Get the JSON from the file as String
        string json = JSONDataFile.ToString();

        // Deserialize JSON from the string and assign to a
        // Collection Array
        _itemCollection = JsonConvert.DeserializeObject<ItemCollection>(json);
    }

    /// <summary>
    /// Instantiates Item Prefabs based on JSON parsed
    /// from the Data File
    /// </summary>
    private void GenerateItemPrefabsFromData()
    {
        // Looping through each Item in the ItemCollection
        foreach (var item in _itemCollection.items)
        {
            // Instantiate a new ItemPrefab
            var newItem = Instantiate(itemPrefab, itemsParent, false);

            // Set Item Values for the newly created Item GameObject
            newItem.GetComponent<ItemManager>().SetItemValues(item, ImagePath);
        }
    }

    private void SetMainFieldsFromData()
    {
        messageOfTheDayText.text = _itemCollection.messageOfTheDay;

        ImagePath = _itemCollection.imagePath;
    }
}
