namespace Features.ScriptableObjects
{
    using Features.UI;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "DocumentEventModel", menuName = "Features/DocumentEventModel")]

    public class DocumentEventModel : ScriptableObject
    {
        public event Action<Document> OnAddDocument;

        public void AddDocument(Document document)
        {
            OnAddDocument?.Invoke(document);
        }
    }
}
