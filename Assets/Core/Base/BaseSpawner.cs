using Core.Interfaces;

namespace Core.Base
{
    public abstract class BaseSpawner<T> : BaseEntity where T : IEntity
    {
        private float _produceTimeLeft;

        private readonly float _produceTime;

        public abstract T Produce();

        protected BaseSpawner(float produceTime)
        {
            _produceTime = produceTime;
        }
        
        public override void Simulate(float deltaTime)
        {
            _produceTimeLeft += deltaTime;

            if (!(_produceTimeLeft > _produceTime))
                return;
            
            T spawnedEntity = Produce();
            EventBus.OnCreated(spawnedEntity);

            _produceTimeLeft = 0;
        }
    }
}