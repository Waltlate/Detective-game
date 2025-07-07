namespace Features.UI
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Selector for quality game
    /// </summary>
    public class QualityLevelSelector : MonoBehaviour
    {
        [SerializeField] private Dropdown _qualityDropdown;

        private void Start()
        {
            _qualityDropdown.ClearOptions();
            _qualityDropdown.AddOptions(new List<string>(QualitySettings.names));
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("QualityLevel", QualitySettings.names.Length - 1));
            _qualityDropdown.value = QualitySettings.GetQualityLevel();
            _qualityDropdown.RefreshShownValue();
            _qualityDropdown.onValueChanged.AddListener(OnQualityChange);
        }

        private void OnDestroy()
        {
            _qualityDropdown.onValueChanged.RemoveListener(OnQualityChange);
        }

        private void OnQualityChange(int index)
        {
            QualitySettings.SetQualityLevel(index);
            PlayerPrefs.SetInt("QualityLevel", QualitySettings.GetQualityLevel());
        }
    }
}
