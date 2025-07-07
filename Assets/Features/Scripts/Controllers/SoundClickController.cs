namespace Features.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class SoundClickController : MonoBehaviour
    {
        [SerializeField] private AudioClip _clip;
        [SerializeField] private AudioSource _audioSource;

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                _audioSource.PlayOneShot(_clip);
            }
        }
    }
}
