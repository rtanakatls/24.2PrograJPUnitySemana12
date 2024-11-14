using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneButton : MonoBehaviour
{
    [SerializeField] private string sceneName;
    


    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => { SceneManager.LoadScene(sceneName); });
    }
}
