namespace Features.Core
{
    using UnityEngine;

    /// <summary>
    /// Abstract audiosource class
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public abstract class AbstractAudioSource : MonoBehaviour
    {
        public AudioSource Audio => audio;
        protected AudioSource audio = default;

        protected virtual void Awake() => audio = GetComponent<AudioSource>();

        protected abstract void OnEnable();
    }
}
