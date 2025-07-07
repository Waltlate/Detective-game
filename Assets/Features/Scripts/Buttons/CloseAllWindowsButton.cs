namespace Features.Buttons
{
    using Features.Controllers;
    using Features.Core;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CloseAllWindowsButton : AbstractButton
    {
        [SerializeField] private DocumentViewController _documentViewController;

        protected override void OnButtonClicked()
        {
            _documentViewController.CollapseDocuments();
        }
    }
}
