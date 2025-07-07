namespace Features.Buttons
{
    using Features.Core;
    using UnityEngine;

    /// <summary>
    /// Audio play on button 
    /// </summary>
    public class QuitButton : AbstractButton
    {
        protected override void OnButtonClicked()
        {
            Application.Quit();
        }
    }
}
