namespace Features.Controllers
{
    using Features.Buttons;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class JournalController : MonoBehaviour
    {
        [SerializeField] private List<EntryButton> _buttons;
        [SerializeField] private EntryButton _oldButton;

        private void Awake()
        {
            _buttons.ForEach(obj => obj.OnClick += UpdateButtons);
        }

        private void UpdateButtons(EntryButton entryButton)
        {
            if(_oldButton != entryButton)
            {
                _oldButton.CompressButton();
                _oldButton = entryButton;
            }
        }
    }
}
