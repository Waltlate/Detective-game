namespace Features.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ImageDocument : MonoBehaviour
    {
        [SerializeField] private Sprite _sprite;

        public Sprite MainSprite => _sprite;
    }
}
