namespace Features.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class Greatings : MonoBehaviour
    {
        [SerializeField] private Document _greatingsDocument;

        private Button _button;

        private void Awake()
        {
            _button = _greatingsDocument.transform.GetComponent<Button>();

            if (_greatingsDocument.IsInit)
            {
                ActiveWindow();
            }
            else
            {
                _greatingsDocument.OnInit += ActiveWindow;
            }
        }

        private void ActiveWindow()
        {
            _button.onClick.Invoke();
            _button.onClick.Invoke();
        }

        private void OnDestroy()
        {
            _greatingsDocument.OnInit -= ActiveWindow;
        }
    }
}
