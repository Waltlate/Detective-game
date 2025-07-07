namespace Features.UI
{
    using Features.ScriptableObjects;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class TextDocument : MonoBehaviour
    {
        [SerializeField] private string _text;

        public string MainText 
        { 
            get { return _text; }
            set { _text = value; }
        }
    }
}
