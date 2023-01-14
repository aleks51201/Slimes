using System;

namespace SlimeEvolutions.Buttons
{
    public class ButtonWithClick : ButtonMain
    {
        public Action OnButtonClickEvent;


        public void OnClick()
        {
            if (!IsActive)
            {
                return;
            }
            OnButtonClickEvent?.Invoke();
        }
    }
}
