namespace Features.ScriptableObjects
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "WinModel", menuName = "Features/WinModel")]

    public class WinModel : ScriptableObject
    {
        public event Action OnUpdateDetails = delegate { };

        private List<bool> _isActive = new List<bool>(new bool[6]);
        private bool _isWin;

        public bool IsWin
        {
            get { return _isWin; }
            set { _isWin = value; }
        }

        public List<bool> IsActive => _isActive;

        public void ActiveDetail(int number)
        {
            _isActive[number] = true;
        }

        public void Clear()
        {
            _isWin = false;
            for (int i = 0; i < _isActive.Count; i++)
            {
                _isActive[i] = false;
            }
        }
    }
}
