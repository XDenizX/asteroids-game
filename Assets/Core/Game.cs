using System;
using System.Collections.Generic;
using Core.Interfaces;
using Core.Spaceships;
using Core.Spawners;

namespace Core
{
    public class Game
    {
        private readonly ICollection<IEntity> _entities;
        private readonly ICollection<IEntity> _addPendingEntities;
        private readonly ICollection<IEntity> _removePendingEntities;

        public event EventHandler<IEntity> EntityCreated;
        public event EventHandler<IEntity> EntityRemoved;
        public event Action Started; 

        public int Score { get; set; }
        public Spaceship Player { get; set; }
        
        public Game()
        {
            _entities = new List<IEntity>();
            _addPendingEntities = new List<IEntity>();
            _removePendingEntities = new List<IEntity>();
            
            EventBus.Created += AddEntity;
            EventBus.Destroyed += RemoveEntity;
            EventBus.CosmicBodyHit += OnCosmicBodyHit;
        }

        private void OnCosmicBodyHit(ICosmicBody cosmicBody)
        {
            Score += 100;
        }

        public void Start()
        {
            Score = 0;
            Player = new Spaceship();
            AddEntity(Player);
            AddEntity(new AsteroidSpawner(3f)
            {
                SpawnRadius = 15f,
                TargetAreaRadius = 5f
            });
            AddEntity(new SaucerSpawner(Player, 10f)
            {
                SpawnRadius = 15f
            });
            
            Started?.Invoke();
        }
        
        public void Evaluate(float deltaTime)
        {
            ProcessRemovePending();
            ProcessAddPending();
            
            foreach (IEntity entity in _entities)
            {
                entity.Simulate(deltaTime);
            }
        }

        public void AddEntity(IEntity entity)
        {
            _addPendingEntities.Add(entity);
        }

        public void RemoveEntity(IEntity entity)
        {
            _removePendingEntities.Add(entity);
        }

        private void ProcessAddPending()
        {
            foreach (IEntity pendingEntity in _addPendingEntities)
            {
                _entities.Add(pendingEntity);
                EntityCreated?.Invoke(this, pendingEntity);
            }
            _addPendingEntities.Clear();
        }

        private void ProcessRemovePending()
        {
            foreach (IEntity pendingEntity in _removePendingEntities)
            {
                bool isRemoved = _entities.Remove(pendingEntity);
                if (!isRemoved)
                    continue;
                
                EntityRemoved?.Invoke(this, pendingEntity);
            }
            _removePendingEntities.Clear();
        }

        public void Restart()
        {
            foreach (IEntity entity in _entities)
            {
                entity.Destroy();
            }
            
            Start();
        }
    }
}