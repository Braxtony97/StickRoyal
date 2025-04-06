using System.Collections.Generic;
using UnityEngine;
using static Enums;

[CreateAssetMenu(fileName = "SceneDatabase", menuName = "Scriptable Objects/SceneDatabase")]
public class SceneDatabase : ScriptableObject
{
    [SerializeField] private List<SceneData> _scenes;

    private Dictionary<SceneType, string> _sceneDictionary;

    private void OnEnable()
    {
        _sceneDictionary = new Dictionary<SceneType, string>();
        
        foreach (var scene in _scenes)
        {
            _sceneDictionary[scene.SceneType] = scene.SceneName;
        }
    }

    public string GetSceneName(SceneType type)
    {
        return _sceneDictionary.TryGetValue(type, out var sceneName) ? sceneName : null;
    }
}

[System.Serializable]
public class SceneData
{
    public Enums.SceneType SceneType => _sceneType;
    public string SceneName => _sceneName;
    
    [SerializeField] private Enums.SceneType _sceneType;
    [SerializeField] private string _sceneName;
}
