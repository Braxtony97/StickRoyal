using UnityEngine;
using Zenject;

public class GameBootstrapper : MonoBehaviour
{
    [Inject(Id = Enums.LoadServiceType.Unity)] 
    private ILoadService _unityLoadService;
    
    private void Awake()
    {
        Application.targetFrameRate = 60;
        LoadGame();
    }

    private void LoadGame()
    {
        _unityLoadService.Load(Enums.SceneType.Main);
    }
}
