using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    #region Public Variables

    [Header("Item Image")]
    public Image itemImage;

    [Header("Item Title")] 
    public TextMeshProUGUI itemTitleText;

    [Header("Item Available Icon")] 
    public Image itemAvailableIconImage;

    #endregion

    /// <summary>
    /// Assigns Values to the Item Fields based on the Item
    /// Class provided
    /// </summary>
    /// <param name="item">Item class</param>
    public void InitializeItemValues(Item item)
    {
        
    }
}
