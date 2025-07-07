namespace Features.Core
{
    using Features.Controllers;
    using UnityEngine;

    /// <summary>
    /// Basic abstract view to download
    /// </summary>
    public abstract class AbstractLoadView : MonoBehaviour
    {
        protected virtual void OnEnable() => LoadingController.OnSceneProgressLoadChanged += OnUpdateProgressValue;

        protected virtual void OnDisable() => LoadingController.OnSceneProgressLoadChanged -= OnUpdateProgressValue;

        /// <summary>
        /// Что делать view по факту получения сигнала о проценте загрузки
        /// </summary>
        /// <param name="inputValue"></param>
        public abstract void OnUpdateProgressValue(float inputValue);
    }
}