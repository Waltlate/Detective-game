namespace Features.ScriptableObjects
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "EntryModel", menuName = "Features/EntryModel")]
    public class EntryModel : ScriptableObject
    {
        [SerializeField] private Sprite _mainSprite;
        [SerializeField] private string _entryType;
        [SerializeField] private string _entryDiscarge;
        [SerializeField] private string _entryLocation;

        public Sprite MainSprite => _mainSprite;
        public string EntryType =>_entryType;
        public string EntryDiscarge => _entryDiscarge;
        public string EntryLocation => _entryLocation;
    }
}
