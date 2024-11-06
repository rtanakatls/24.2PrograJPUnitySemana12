using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InsertBookController : MonoBehaviour
{

    public void ExecuteSendRequest(string title, int pages, Action<MessageModel> OnCallback)
    {
        StartCoroutine(SendRequest(title, pages, OnCallback));
    }

    IEnumerator SendRequest(string title, int pages, Action<MessageModel> OnCallback)
    {
        WWWForm form = new WWWForm();
        form.AddField("title", title);
        form.AddField("pages", pages);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/prograjp242/biblioteca/insert_book.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ProtocolError ||
                www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("error");
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                OnCallback?.Invoke(JsonUtility.FromJson<MessageModel>(www.downloadHandler.text));
            }
        }

    }
}
