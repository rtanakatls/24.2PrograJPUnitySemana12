using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InsertBookView : MonoBehaviour
{
    [SerializeField] private TMP_InputField titleInputField;
    [SerializeField] private TMP_InputField pageInputField;
    [SerializeField] private Button insertButton;
    private InsertBookController controller;
    private GetAllBooksView getAllBooksView;

    private void Awake()
    {
        controller = GetComponent<InsertBookController>();
        getAllBooksView = GetComponent<GetAllBooksView>();
        insertButton.onClick.AddListener(Execute);
    }

    private void Execute()
    {
        controller.ExecuteSendRequest(
            titleInputField.text,
            int.Parse(pageInputField.text),
            OnCallback
            );
    }

    private void OnCallback(MessageModel result)
    {
        if (result != null && result.message == "success")
        {
            getAllBooksView.Execute();
        }
    }

}
