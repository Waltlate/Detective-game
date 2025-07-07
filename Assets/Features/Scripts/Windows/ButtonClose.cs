namespace Features.Windows
{
    using Features.Core;

    /// <summary>
    /// Button close current view
    /// </summary>
    public class ButtonClose : AbstractButton
    {
        protected override void OnButtonClicked() => WindowsController.onWindowClose();
    }
}
