namespace Features.Buttons
{
    using Features.Core;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class CloseDevelopersButton : AbstractButton
    {
        [SerializeField] private ManageGameObject _main;
        [SerializeField] private Button _menuButton;

        protected override void OnButtonClicked()
        {
            _menuButton.interactable = true;
            _main.Disactive();
        }
    }
}
