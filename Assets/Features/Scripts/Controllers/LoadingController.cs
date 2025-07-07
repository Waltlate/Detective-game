namespace Features.Controllers
{
    using System;
    using UnityEngine;
    using System.Collections;
    using UnityEngine.SceneManagement;

    public class LoadingController : MonoBehaviour
    {
        public static event Action<float> OnSceneProgressLoadChanged = delegate { };

        public static string NameNextScene = "Menu";

        protected float loadProgress = 0f;
        public float LoadProgress
        {
            get => loadProgress;
            protected set
            {
                if (loadProgress != value)
                {
                    loadProgress = value;
                    OnSceneProgressLoadChanged(loadProgress);
                }
            }
        }

        [SerializeField, Min(0)] protected float startDelay = 1.0f;
        [SerializeField, Min(0)] protected float loadingTimeout = 3.0f;

        public static void StartLoad() => SceneManager.LoadSceneAsync("Loading");

        protected IEnumerator Start()
        {
            yield return new WaitForSecondsRealtime(startDelay);

            Resources.UnloadUnusedAssets();
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(NameNextScene);

            asyncOperation.allowSceneActivation = false;
            while (!asyncOperation.isDone && isActiveAndEnabled)
            {
                LoadProgress = asyncOperation.progress;
                if (asyncOperation.progress >= 0.9f && Time.timeSinceLevelLoad > loadingTimeout)
                {
                    asyncOperation.allowSceneActivation = true;
                }
                yield return null;
            }
        }
    }
}