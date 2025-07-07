namespace Features
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using UnityEngine;
    using Newtonsoft.Json;
    using Features.ScriptableObjects;

    public class DocumentsTextParser : MonoBehaviour
    {
        [SerializeField] private TextsModel _textsModel;

        private string json;

        private void Awake()
        {
            string path = "";

#if UNITY_ANDROID && !UNITY_EDITOR
        path = "jar:file://" + Application.dataPath + "!/assets/Languages/" + PlayerPrefs.GetString("Languages", "ENG") + ".json";
        StartCoroutine(ReadFileFromAndroid(path));
#else
            path = Path.Combine(Application.streamingAssetsPath, "Texts", "doc.json");

            using (StreamReader reader = new StreamReader(path, System.Text.Encoding.UTF8))
            {
                json = reader.ReadToEnd();
            }

            var wrapper = JsonConvert.DeserializeObject<TextsWrapper>(json);

            if (wrapper == null || wrapper.texts == null)
            {
                Debug.LogError("Ошибка десериализации! Wrapper или texts равны null.");
                return; 
            }

            _textsModel.Init(wrapper.texts);
#endif
        }
        private IEnumerator ReadFileFromAndroid(string path)
        {
            yield return null; 
        }
    }
}
