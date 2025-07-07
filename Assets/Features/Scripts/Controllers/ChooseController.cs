namespace Features.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;

    public class ChooseController : MonoBehaviour
    {
        public event Action<AnswerEnum.Answer> OnAnswerChange = delegate { };

        [SerializeField] private List<ManageGameObject> _correctImages;
        [SerializeField] private ManageGameObject _chartDetails;
        [SerializeField] private TMP_Dropdown _dropdown1;
        [SerializeField] private TMP_Dropdown _dropdown2;
        [SerializeField] private TMP_Dropdown _dropdown3;
        [SerializeField] private AudioClip _clip;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Vector3Int _correctAnswer;

        private AnswerEnum.Answer _answerType;
        private Vector3Int _currentAnswer;

        public AnswerEnum.Answer AnswerType => _answerType;

        private void Awake()
        {
            _dropdown1.onValueChanged.AddListener(ChangeAnswer1);
            _dropdown2.onValueChanged.AddListener(ChangeAnswer2);
            _dropdown3.onValueChanged.AddListener(ChangeAnswer3);
        }

        public void CorrectView()
        {
            _dropdown1.interactable = false;
            _dropdown2.interactable = false;
            _dropdown3.interactable = false;
            _chartDetails.Active();
            _correctImages.ForEach(obj => obj.Active());
        }

        private void OnDestroy()
        {
            _dropdown1.onValueChanged.RemoveListener(ChangeAnswer1);
            _dropdown2.onValueChanged.RemoveListener(ChangeAnswer2);
            _dropdown3.onValueChanged.RemoveListener(ChangeAnswer3);
        }

        private void ChangeAnswer1(int number)
        {
            _currentAnswer.x = number;
            UpdateAnswer();
        }

        private void ChangeAnswer2(int number)
        {
            _currentAnswer.y = number;
            UpdateAnswer();
        }

        private void ChangeAnswer3(int number)
        {
            _currentAnswer.z = number;
            UpdateAnswer();
        }

        private void UpdateAnswer()
        {
            _audioSource.PlayOneShot(_clip);

            if (_currentAnswer.x == 0 || 
                _currentAnswer.y == 0 || 
                _currentAnswer.z == 0)
            {
                _answerType = AnswerEnum.Answer.None;
            }
            else if(_currentAnswer == _correctAnswer)
            {
                _answerType = AnswerEnum.Answer.Correct;
            }
            else
            {
                _answerType = AnswerEnum.Answer.Incorrect;
            }

            OnAnswerChange?.Invoke(_answerType);
        }
    }
}
