using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FormTestController : MonoBehaviour
{

    public void ExecuteSendRequest(int number1, int number2, Action<MathResultModel> OnCallback)
    {
        StartCoroutine(SendRequest(number1, number2,OnCallback));
    }

    IEnumerator SendRequest(int number1, int number2, Action<MathResultModel> OnCallback)
    {
        WWWForm form = new WWWForm();
        form.AddField("number1", number1);
        form.AddField("number2", number2);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/prograjp242/unity.php", form))
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
                OnCallback?.Invoke(JsonUtility.FromJson<MathResultModel>(www.downloadHandler.text));
            }
        }

    }
}
