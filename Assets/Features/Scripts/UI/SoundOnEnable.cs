namespace Features.UI
{
    using Features.Core;

    /// <summary>
    /// Sound on 
    /// </summary>
    public class SoundOnEnable : AbstractAudioSource
    {
        protected override void OnEnable()
        {
            audio.volume = AudioModel.SoundVolume;
            audio.Play();
        }
    }
}
