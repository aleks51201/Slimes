namespace SlimeEvolutions.Panel.Laboratory.Behaviours
{
    public interface ILaboratoryBehaviour:IActivatable
    {
        public void Enter(LaboratoryLogic laboratoryLogic);
        public void Exit();
    }
}
