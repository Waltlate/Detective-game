namespace Features
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ManageGameObject : MonoBehaviour
    {
        public void Active()
        {
            gameObject.SetActive(true);
        }

        public void Disactive()
        {
            gameObject.SetActive(false);
        }
    }
}
