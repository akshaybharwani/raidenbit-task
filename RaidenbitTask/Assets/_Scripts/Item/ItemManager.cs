using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[RequireComponent(typeof(LoadImageFromURL))]
public class ItemManager : MonoBehaviour
{
    #region Public Variables

    [Header("Item Image")]
    public Image itemImage;

    [Header("Item Title")] 
    public TextMeshProUGUI itemTitleText;

    [Header("Item Available Icon")] 
    public Image itemAvailableIconImage;

    [Header("Item Button")] 
    public Button itemOpenURLButton;
    
    [Header("Load Image From URL")]
    public LoadImageFromURL loadImageFromURL;

    #endregion

    #region Private Variables

    // Reference to store Item's URL if available
    private string _itemURL;

    private Sprite spriteDownloaded;

    #endregion

    private void Start()
    {
        
    }

    /// <summary>
    /// Assigns Values to the Item Fields based on the Item
    /// Class provided
    /// </summary>
    /// <param name="item"></param>
    /// <param name="imagePath"></param>
    public void SetItemValues(Item item, string imagePath)
    {
        // Build the Image URL using the Path
        var imageURLToDownload = imagePath + item.image;
        
        // Set Item Image
        StartCoroutine(loadImageFromURL.DownloadImageFromURLAndAssign(
            imageURLToDownload, itemImage));
        
        // Set Item Title
        itemTitleText.text = item.title;

        // Toggle Available status based on Item's Available bool
        ToggleItemAvailableStatus(item.available);

        // If Item's URL is available, assign it the variable
        if (item.available)
            _itemURL = item.address;
    }

    /// <summary>
    /// Opens a Web Browser based on URL specified
    /// </summary>
    public void OpenURL()
    {
        Application.OpenURL(_itemURL);
    }

    /// <summary>
    /// If true, shows Available Icon and Item can be clicked to
    /// open URL,
    /// If false, hides Available Icon and Item can't be clicked
    /// </summary>
    /// <param name="toggleValue"></param>
    private void ToggleItemAvailableStatus(bool toggleValue)
    {
        itemAvailableIconImage.enabled = !toggleValue;
        itemOpenURLButton.enabled = toggleValue;
    }
    
    
}
