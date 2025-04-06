using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class UnityLoadService : ILoadService
{
    [Inject] private CoroutineRunner _coroutineRunner;
    [Inject] private SceneDatabase _sceneDatabase;
    
    public void Load(object data)
    {
        if (data is Enums.SceneType type)
        {
            var sceneName = _sceneDatabase.GetSceneName(type);
            
            _coroutineRunner.StartCoroutine(LoadScene(sceneName));
        }
    }

    private IEnumerator LoadScene(string sceneName)
    {
        if (SceneManager.GetActiveScene().name == sceneName)
            yield break;
        
        var waitLoadScene = SceneManager.LoadSceneAsync(sceneName);

        while (!waitLoadScene.isDone)
        {
            yield return null;
        }
    }
}