namespace Features.Buttons
{
    using Features.Core;
    using Features.UI;
    using UnityEngine;

    /// <summary>
    /// Audio play on button 
    /// </summary>
    public class SoundButton : AbstractButton
    {
        [SerializeField] protected AudioClip clickSound;

        protected AudioSource audioSource;

        protected virtual void Start()
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = clickSound;
        }

        protected override void OnButtonClicked()
        {
            audioSource.volume = AudioModel.SoundVolume;
            audioSource.Play();
        }
    }
}
