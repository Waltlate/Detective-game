namespace Features.Controllers
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class MusicController : MonoBehaviour
    {
        [SerializeField] protected AudioClip menuMusic;
        [SerializeField] protected AudioClip gameMusic;
        [SerializeField] protected AudioClip loadingMusic;

        protected AudioSource audioSource;

        protected void Awake()
        {
            if (FindObjectsOfType<MusicController>().Length > 1)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }

        protected virtual void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            PlayMusicForScene(SceneManager.GetActiveScene().name);
        }

        protected void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            PlayMusicForScene(scene.name);
        }

        protected void PlayMusicForScene(string sceneName)
        {
            switch (sceneName)
            {
                case "Menu":
                    ChangeMusic(menuMusic);
                    break;
                case "Game":
                    ChangeMusic(gameMusic);
                    break;
                case "Loading":
                    ChangeMusic(loadingMusic);
                    break;
            }
        }

        protected void ChangeMusic(AudioClip newClip)
        {
            if (audioSource.clip != newClip)
            {
                audioSource.clip = newClip;
                audioSource.Play();
            }
        }

        protected void OnDestroy() => SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
