using UnityEngine;
using Zenject;
using static Enums;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private CoroutineRunner _coroutineRunner;
    [SerializeField] private SceneDatabase _sceneDatabase;
    
    public override void InstallBindings()
    {
        Container.Bind<CoroutineRunner>().FromInstance(_coroutineRunner).AsSingle().NonLazy();
        Container.Bind<SceneDatabase>().FromInstance(_sceneDatabase).AsSingle().NonLazy();
        
        Container.Bind<ILoadService>().WithId(LoadServiceType.Unity).To<UnityLoadService>().AsSingle().NonLazy();
    }
}
