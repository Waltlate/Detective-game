namespace Features.ScriptableObjects
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "MusicModel", menuName = "Features/MusicModel")]
    public class MusicModel : ScriptableObject
    {
        public event Action OnChangeVolume = delegate { };

        private float _volume = 1;

        public float Volume
        {
            get { return _volume; }
            set
            {
                _volume = value;
                OnChangeVolume?.Invoke();
            }
        }
    }
}
