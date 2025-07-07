namespace Features.Windows
{
    using Features.Core;
    using UnityEngine;

    /// <summary>
    /// Button open current view
    /// </summary>
    public class ButtonOpen : AbstractButton
    {
        [SerializeField] protected Window windowPrefab = default;

        protected override void OnButtonClicked() => WindowsController.onWindowOpen(windowPrefab.Id);
    }
}