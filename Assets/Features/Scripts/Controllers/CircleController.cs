namespace Features.Controllers
{
    using Features.ScriptableObjects;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class CircleController : MonoBehaviour
    {
        [SerializeField] private WinModel _winModel;
        [SerializeField] private List<ManageGameObject> _details;
        [SerializeField] private Button _button;

        private void Awake()
        {

            for (int i = 0; i < _winModel.IsActive.Count; i++)
            {
                _details[i].Disactive();
            }

            _winModel.Clear();
        }

        private void OnEnable()
        {
            ActiveDetails();
            ActiveButton();
        }

        private void ActiveDetails()
        {
            for(int i = 0; i < _winModel.IsActive.Count; i++)
            {
                if (_winModel.IsActive[i])
                {
                    _details[i].Active();
                }
            }
        }

        private void ActiveButton()
        {
            if (_winModel.IsWin)
            {
                _button.interactable = true;
            }
        }
    }
}
