namespace Features.Controllers
{
    using Features.ScriptableObjects;
    using Features.Windows;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class EndController : MonoBehaviour
    {
        private const string _winWindow = "Win";
        private const string _failWindow = "Fail";
        private const int _failCount = 3;
        private const int _winCount = 6;

        [SerializeField] private WinModel _winModel;
        [SerializeField] private List<ChooseController> _chooseControllers;

        private int _correctAnswers;
        private int _incorrectAnswers;

        private void Awake()
        {
            _chooseControllers.ForEach(obj => obj.OnAnswerChange += UpdateEvents);
        }

        private void UpdateEvents(AnswerEnum.Answer answer)
        {
            _correctAnswers = 0;
            _incorrectAnswers = 0;

            foreach (var choose in _chooseControllers)
            {
                if(choose.AnswerType == AnswerEnum.Answer.Correct)
                {
                    _correctAnswers++;
                }

                if (choose.AnswerType == AnswerEnum.Answer.Incorrect)
                {
                    _incorrectAnswers++;
                }
            }
            CheckEvents();
        }

        private void CheckEvents()
        {
            if(_correctAnswers % 2 == 0 && _correctAnswers != 0)
            {
                foreach(var elem in _chooseControllers)
                {
                    if(elem.AnswerType == AnswerEnum.Answer.Correct)
                    {
                        elem.CorrectView();
                    }
                }

                for(int i = 0; i < _chooseControllers.Count; i++)
                {
                    if (_chooseControllers[i].AnswerType == AnswerEnum.Answer.Correct)
                    {
                        _winModel.ActiveDetail(i);
                    }
                }
            }

            if (_correctAnswers == _winCount)
            {
                _winModel.IsWin = true;
            }
        }
    }
}
