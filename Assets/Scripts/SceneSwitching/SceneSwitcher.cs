using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    /// <summary>
    /// This script manages the scenes that need to be loaded in the right order with additional event listeners.
    /// </summary>
    public static SceneSwitcher Instance;

    [SerializeField]
    private List<string> _scenes; // The list of scenes you will be going through

    private int _scene = 0;
    private bool _selectScene = false;

    [SerializeField]
    private UnityEvent _beforeDestroy;
    public UnityEvent BeforeDestroy
    {
        get { return _beforeDestroy; }
        private set { _beforeDestroy = BeforeDestroy; }
    }

    [SerializeField]
    private UnityEvent _onLoad; // When its loading
    public UnityEvent OnLoad
    {
        get { return _onLoad; }
        private set { _onLoad = OnLoad; }
    }

    [SerializeField]
    private UnityEvent _onLoaded; // When its loaded
    public UnityEvent OnLoaded
    {
        get { return _onLoaded; }
        private set { _onLoaded = OnLoaded; }
    }

    void Awake()
    { 
        _beforeDestroy = BeforeDestroy;
        Instance = this;
        if(GameObject.FindGameObjectsWithTag("LevelLoading").Length > 1) {
            Destroy(GameObject.FindGameObjectsWithTag("LevelLoading")[0]);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void SelectScene(int scene) {
        _scene = scene;
        _selectScene = true;
        Debug.LogError(_scene);
    }

    // After it's done with being destroyed
    public void Callback()
    {
        if (_selectScene)
        {
            _onLoad?.Invoke();

            SceneManager.LoadScene(_scenes[_scene]);

            _onLoaded?.Invoke();

            _selectScene = false;
        }
        else
        {
            Debug.LogError("NextLevel");
            _scene = SceneManager.GetActiveScene().buildIndex;

            if (_scene + 1 < _scenes.Count)
            {
                _onLoad?.Invoke();

                _scene++;

                SceneManager.LoadScene(_scenes[_scene]);

                _onLoaded?.Invoke();
            }
        }
    }

    // Going to the next scene
    public void GoToNextScene()
    {
        Debug.LogError("beforeDestroy");
        _beforeDestroy?.Invoke();
    }
}