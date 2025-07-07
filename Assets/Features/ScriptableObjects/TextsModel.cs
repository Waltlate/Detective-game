namespace Features.ScriptableObjects
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "TextsModel", menuName = "Features/TextsModel")]

    public class TextsModel : ScriptableObject
    {
        private Dictionary<string, string> _textDictionary = new Dictionary<string, string>();

        public Dictionary<string, string> TextDictionary => _textDictionary;
        public int _count => _textDictionary.Count;

        public void Init(Dictionary<string, string> dictionary)
        {
            _textDictionary.Clear();
            _textDictionary = new Dictionary<string, string>(dictionary);
        }
    }
}
