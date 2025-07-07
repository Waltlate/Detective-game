namespace Features.Buttons
{
    using Features.Core;
    using Features.UI;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CollapseWindowButton : AbstractButton
    {
        [SerializeField] private WindowDocument _windowDocument;
        protected override void OnButtonClicked()
        {
            _windowDocument.Collapse();
        }
    }
}
