using Features.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Features.UI
{
    public class VolumeChanger : MonoBehaviour
    {
        [SerializeField] private MusicModel _musicModel;

        private AudioSource _source;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
            _musicModel.OnChangeVolume += UpdateVolume;
        }

        private void OnEnable()
        {
            UpdateVolume();
        }

        private void UpdateVolume()
        {
            if(_source != null)
            {
                _source.volume = _musicModel.Volume;
            }
        }

        private void OnDestroy()
        {
            _musicModel.OnChangeVolume -= UpdateVolume;
        }
    }
}
