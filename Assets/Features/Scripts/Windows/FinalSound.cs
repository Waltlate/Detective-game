namespace Features.Windows
{
    using Features.Core;
    using Features.UI;
    using UnityEngine;

    /// <summary>
    /// Sound gameover
    /// </summary>
    public class FinalSound : AbstractAudioSource
    {
        [SerializeField] protected AudioClip gameOverSound;
        [SerializeField] private string _nameWindow;

        protected override void OnEnable()
        {
            WindowsController.onWindowChanged += Sound;
        }

        protected void Sound(string name)
        {
            if(name == _nameWindow)
            {
                audio.volume = AudioModel.SoundVolume;
                audio.PlayOneShot(gameOverSound);
                audio.Play();
            }
        }

        protected void Disable()
        {
            WindowsController.onWindowChanged -= Sound;
        }
    }
}
