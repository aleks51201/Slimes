namespace SlimeEvolutions.Architecture.Scene.Instances
{
    public sealed class NewSceneManager : SceneManagerBase
    {
        public override void InitializeSceneMap()
        {
            sceneConfigMap[NewConfig.SCENE_NAME] = new NewConfig();
        }
    }
}
