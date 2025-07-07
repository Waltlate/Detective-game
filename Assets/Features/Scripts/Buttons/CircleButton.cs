namespace Features.Buttons
{
    using Features.Controllers;
    using Features.Core;
    using Features.ScriptableObjects;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CircleButton : AbstractButton
    {
        [SerializeField] private WinController _WinController;

        protected override void OnButtonClicked()
        {
            _WinController.ActiveFinalDocument();
        }
    }
}
