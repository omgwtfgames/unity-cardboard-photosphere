using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneSwitcher : MonoBehaviour {
    public float TapDelay = 1.0f;
    float _tapCountdown;

    int _currentSceneIndex = 0;

    static SceneSwitcher _instance;
    public static SceneSwitcher Instance {
        get {
            return _instance;
        }
        set { }
    }

    void Awake()
    {
        if (_instance != null)
        {
            DestroyImmediate(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }

        _tapCountdown = TapDelay;
    }
	
	void Update () {
	    if (GvrViewer.Instance.Triggered && _tapCountdown <= 0)
        {
            _tapCountdown = TapDelay;

            _currentSceneIndex++;
            if (_currentSceneIndex >= SceneManager.sceneCountInBuildSettings) _currentSceneIndex = 0;
            SceneManager.LoadScene(_currentSceneIndex);

        }
        else
        {
            _tapCountdown -= Time.deltaTime;
        }
	}
}
