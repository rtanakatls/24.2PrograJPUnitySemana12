using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Game1
{
    public class MainSceneView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField usernameInputField;
        [SerializeField] private Button startButton;
        [SerializeField] private string sceneName;

        private void Awake()
        {
            startButton.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            if (usernameInputField.text.Length > 0)
            {
                GameData.username = usernameInputField.text;
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}