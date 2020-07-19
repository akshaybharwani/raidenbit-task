using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class ItemCollection
{
    #region Public Variables

    public string messageOfTheDay;

    public string imagePath;
    
    // An array of Item Class.
    // Arrays would work for a small App like this, but
    // Lists are preferred as a better Generic Type to work with
    public Item[] items;

    #endregion
}
