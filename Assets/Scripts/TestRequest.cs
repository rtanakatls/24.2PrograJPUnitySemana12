using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestRequest : MonoBehaviour
{
    [SerializeField] private MathResultModel resultModel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SendRequest());
    } 


    IEnumerator SendRequest()
    {
        WWWForm form = new WWWForm();
        form.AddField("number1", 10);
        form.AddField("number2", 20);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/prograjp242/unity.php",form))
        {
            yield return www.SendWebRequest();

            if(www.result==UnityWebRequest.Result.ProtocolError || 
                www.result==UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("error");
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                resultModel=JsonUtility.FromJson<MathResultModel>(www.downloadHandler.text);
            }
        }

    }
}
