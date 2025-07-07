namespace Features.Controllers
{
    using Features.ScriptableObjects;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class VolumeController : MonoBehaviour
    {
        [SerializeField] private MusicModel _musicModel;
        [SerializeField] private Slider _slider;

        private void Awake()
        {
            _slider.value = _musicModel.Volume;
            _slider.onValueChanged.AddListener(UpdateVolume);
        }

        private void OnDestroy()
        {
            _slider.onValueChanged.RemoveListener(UpdateVolume);
        }

        private void UpdateVolume(float value)
        {
            _musicModel.Volume = value;
        }
    }
}