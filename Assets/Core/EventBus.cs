using System;
using Core.Interfaces;

namespace Core
{
    public static class EventBus
    {
        public static event Action<IEntity> Created;
        public static event Action<IEntity> Destroyed;
        public static event Action<ICosmicBody> CosmicBodyHit;

        public static void OnCreated(IEntity entity)
        {
            Created?.Invoke(entity);
        }
        
        public static void OnDestroy(IEntity entity)
        {
            Destroyed?.Invoke(entity);
        }
        
        public static void OnCosmicBodyHit(ICosmicBody cosmicBody)
        {
            CosmicBodyHit?.Invoke(cosmicBody);
        }
    }
}