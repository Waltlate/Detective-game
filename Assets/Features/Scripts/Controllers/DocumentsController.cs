namespace Features.Controllers
{
    using Features.UI;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class DocumentsController : MonoBehaviour
    {
        private List<Document> _documents = new List<Document>();

        private void Awake()
        {
            foreach(var doc in transform.GetComponentsInChildren<Document>())
            {
                _documents.Add(doc);
            }
        }
    }
}
