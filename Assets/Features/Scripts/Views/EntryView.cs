namespace Features.Views
{
    using Features.ScriptableObjects;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;

    public class EntryView : MonoBehaviour
    {
        [SerializeField] private EntryEventModel _EntryEventModel;
        [SerializeField] private Image _mainImage;
        [SerializeField] private Text _entryType;
        [SerializeField] private Text _entryDiscarge;
        [SerializeField] private Text _entryLocation;

        private void Awake()
        {
            _EntryEventModel.OnChangeView += UpdateView;
        }

        private void UpdateView(EntryModel entryModel)
        {
            _mainImage.sprite = entryModel.MainSprite;
            _entryType.text = entryModel.EntryType;
            _entryDiscarge.text = entryModel.EntryDiscarge;
            _entryLocation.text = entryModel.EntryLocation;
        }

        private void OnDestroy()
        {
            _EntryEventModel.OnChangeView -= UpdateView;
        }
    }
}
