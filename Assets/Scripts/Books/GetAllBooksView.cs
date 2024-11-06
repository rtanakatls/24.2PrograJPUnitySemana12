using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAllBooksView : MonoBehaviour
{
    [SerializeField] private GameObject dataContainerPrefab;
    [SerializeField] private GameObject container;
    private GetAllBooksController controller;

    private void Awake()
    {
        controller = GetComponent<GetAllBooksController>();
    }

    public void Execute()
    {
        controller.ExecuteSendRequest(OnCallback);

    }


    private void OnCallback(BookDataModel bookDataModel)
    {
        foreach(Transform t in container.transform.GetComponentInChildren<Transform>())
        {
            if(t!=container.transform)
            {
                Destroy(t.gameObject);
            }
        }
        foreach(BookModel book in bookDataModel.data)
        {
            GameObject dataContainer =Instantiate(dataContainerPrefab, container.transform);
            dataContainer.GetComponent<DataContainer>().SetData($"ID: {book.libro_id}\nTítulo: {book.titulo}\nPáginas: {book.paginas}");
        }

    }


}
