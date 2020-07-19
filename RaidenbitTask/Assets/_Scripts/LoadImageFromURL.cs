using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadImageFromURL : MonoBehaviour
{
    /// <summary>
    /// Makes a UnityWebRequest, gets the Image and applies it to
    /// the Image Component specified
    /// </summary>
    /// <param name="url"></param>
    /// <param name="image"></param>
    public void GetImageFromURLAndAssigntoImage(string url, Image image)
    {
        StartCoroutine(ImageRequest(url, req =>
        {
            if (req.isNetworkError || req.isHttpError)
            {
                //Debug.Log($"{req.error}: {req.downloadHandler.text}");
            } else
            {
                // Get the texture out using a helper downloadhandler
                Texture2D texture = DownloadHandlerTexture.GetContent(req);
                // Save it into the Image UI's sprite
                image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), 
                    new Vector2(0.5f, 0.5f));
            }
        }));
    }
    
    /// <summary>
    /// Makes a UnityWebRequest based on the URL
    /// </summary>
    /// <param name="url"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    IEnumerator ImageRequest(string url, Action<UnityWebRequest> callback)
    {
        using (UnityWebRequest req = UnityWebRequestTexture.GetTexture(url))
        {
            yield return req.SendWebRequest();
            callback(req);
        }
    }
}
