﻿namespace SlimeEvolutions.Panel.Crossing.Update.Behaviours
{
    public interface IUpdateViewBehaviour:IActivatable
    {
        public void Enter(UpdateView updateView);
        public void Exit();
    }
}
