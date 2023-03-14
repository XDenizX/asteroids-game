using System;
using Core.Interfaces;

namespace Core.Base
{
    public class BaseEntity : IEntity
    {
        private float _lifetime = 20f;
        
        public event EventHandler Destroyed;
        
        public virtual void Destroy()
        {
            Destroyed?.Invoke(this, EventArgs.Empty);
            EventBus.OnDestroy(this);
        }
        
        public virtual void Simulate(float deltaTime)
        {
            _lifetime -= deltaTime;
            
            if (_lifetime < 0f)
                Destroy();
        }
    }
}