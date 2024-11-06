using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetAllBooksController : MonoBehaviour
{
    public void ExecuteSendRequest( Action<BookDataModel> OnCallback)
    {
        StartCoroutine(SendRequest(OnCallback));
    }

    IEnumerator SendRequest(Action<BookDataModel> OnCallback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/prograjp242/biblioteca/select_all_books.php"))
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
                OnCallback?.Invoke(JsonUtility.FromJson<BookDataModel>(www.downloadHandler.text));
            }
        }

    }
}
