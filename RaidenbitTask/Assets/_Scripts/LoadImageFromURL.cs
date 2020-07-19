using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadImageFromURL : MonoBehaviour
{
    private void Start()
    {
        
    }

    public IEnumerator DownloadImageFromURLAndAssign(string url, Image image)
    {
        // Create a Unity Web Request for Texture
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);

        //Send Request and wait
        yield return www.SendWebRequest();

        // If there is an error then return
        if (www.isHttpError || www.isNetworkError)
        {
            Debug.Log("Error while Receiving: " + www.error);
        }
        else
        {
            //Load Image
            Texture2D texture2d = DownloadHandlerTexture.GetContent(www);

            // Create a Sprite out of the Texture
            Sprite sprite = null;
            sprite = Sprite.Create(texture2d, new Rect(0, 0, texture2d.width, texture2d.height), Vector2.zero);

            if (sprite != null)
            {
                // Assign the Sprite to the Image
                image.sprite = sprite;
            }
        }
    }
}
