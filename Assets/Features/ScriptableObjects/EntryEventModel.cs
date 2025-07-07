namespace Features.ScriptableObjects
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "EntryEventModel", menuName = "Features/EntryEventModel")]
    public class EntryEventModel : ScriptableObject
    {
        public event Action<EntryModel> OnChangeView;

        public void ChangeView(EntryModel entryModel)
        {
            OnChangeView?.Invoke(entryModel);
        }
    }
}
