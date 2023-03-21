using System;
using System.Collections.Generic;
using Base;
using Core.CosmicBodies;
using Core.Interfaces;
using Core.Projectiles;
using Core.Spaceships;
using Interfaces;
using Presenters;
using UnityEngine;
using Views;
using Ray = Core.Projectiles.Ray;

public class ViewBuilder : MonoBehaviour
{
    [SerializeField] private SpaceshipView spaceshipPrefab;
    [SerializeField] private BulletView bulletPrefab;
    [SerializeField] private RayView rayPrefab;
    [SerializeField] private AsteroidView asteroidPrefab;
    [SerializeField] private SaucerView saucerPrefab;
    [SerializeField] private FragmentView fragmentPrefab;
    
    private readonly Dictionary<Type, Type> _presentersMap = new();
    private readonly Dictionary<Type, Type> _viewsMap = new();
    private readonly Dictionary<Type, GameObject> _prefabMap = new();

    private void Awake()
    {
        Register<Spaceship, SpaceshipPresenter, SpaceshipView>(spaceshipPrefab);
        Register<Bullet, BulletPresenter, BulletView>(bulletPrefab);
        Register<Ray, RayPresenter, RayView>(rayPrefab);
        Register<Asteroid, AsteroidPresenter, AsteroidView>(asteroidPrefab);
        Register<Saucer, SaucerPresenter, SaucerView>(saucerPrefab);
        Register<Fragment, FragmentPresenter, FragmentView>(fragmentPrefab);
    }

    private void Register<TModel, TPresenter, TView>(TView viewComponent)
        where TModel : IEntity
        where TPresenter : BasePresenter<TModel, TView>
        where TView : Component, IViewFor<TPresenter>
    {
        if (viewComponent == null)
        {
            Debug.LogErrorFormat("[{0}] Component for registration '{1}' is null", nameof(ViewBuilder), nameof(TModel));
            return;
        }

        _presentersMap.Add(typeof(TModel), typeof(TPresenter));
        _viewsMap.Add(typeof(TModel), typeof(TView));
        _prefabMap.Add(typeof(TModel), viewComponent.gameObject);
    }
    
    public bool TryCreateView(IEntity entity, out GameObject view)
    {
        view = null;
        Type entityType = entity.GetType();

        if (!_viewsMap.TryGetValue(entityType, out _))
            return false;
        
        if (!_presentersMap.TryGetValue(entityType, out Type presenterType))
            return false;
        
        if (!_prefabMap.TryGetValue(entityType, out GameObject prefab))
            return false;

        GameObject prefabInstance = Instantiate(prefab);
        IView viewComponent = prefabInstance.GetComponent<IView>();
        var presenterInstance = (IPresenter)Activator.CreateInstance(presenterType, entity, viewComponent);
        viewComponent.Presenter = presenterInstance;
        presenterInstance.Enable();

        view = prefabInstance;
        
        return true;
    }
}