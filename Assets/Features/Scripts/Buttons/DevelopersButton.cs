namespace Features.Buttons
{
    using Features.Core;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class DevelopersButton : AbstractButton
    {
        [SerializeField] private ManageGameObject _main;

        protected override void OnButtonClicked()
        {
            ButtonInstance.interactable = false;
            _main.Active();
        }
    }
}
