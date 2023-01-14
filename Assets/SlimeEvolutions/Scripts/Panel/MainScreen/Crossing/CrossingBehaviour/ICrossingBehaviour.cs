namespace SlimeEvolutions.Panel.Crossing.Behaviour
{
    public interface ICrossingBehaviour : IActivatable
    {
        public void Enter(CrossPlaceLogic CrossLogic);
        public void Exit();
    }
}
