namespace Features.UI
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Class for management audio
    /// </summary>
    public static class AudioModel
    {
        private const float _startVolume = 1f;

        /// <summary>
        /// Subscribe on sound volume change
        /// </summary>
        public static event Action onSoundVolumeChanged = delegate { };

        public static float SoundVolume
        {
            get => PlayerPrefs.GetFloat("SoundVolume", _startVolume);
            set
            {
                PlayerPrefs.GetFloat("SoundVolume", value);
                PlayerPrefs.Save();
                onSoundVolumeChanged();
            }
        }
    }
}
