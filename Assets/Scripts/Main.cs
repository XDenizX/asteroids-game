using System.Collections.Generic;
using Core;
using Core.Interfaces;
using UnityEngine;

[RequireComponent(typeof(ViewBuilder))]
[RequireComponent(typeof(UI))]
public class Main : MonoBehaviour
{
    private Camera _mainCamera;

    private Dictionary<IEntity, GameObject> _instanceMap;
    private ViewBuilder _viewBuilder;
    private UI _ui;
    private Game _game;

    private void Awake()
    {
        _instanceMap = new Dictionary<IEntity, GameObject>();
        _game = new Game();
        
        _viewBuilder = GetComponent<ViewBuilder>();
        _ui = GetComponent<UI>();
        _mainCamera = Camera.main;

        _game.EntityCreated += OnEntityCreated;
        _game.EntityRemoved += OnEntityRemoved;
        _game.Started += OnGameStart;
    }

    private void OnGameStart()
    {
        _ui.SetGame(_game);
        
        float height = 2f * _mainCamera.orthographicSize;
        float width = height * _mainCamera.aspect;
        _game.AddEntity(new GameArea(_game.Player, width, height));
    }

    private void Start()
    {
        _game.Start();
    }

    private void Update()
    {
        _game.Evaluate(Time.deltaTime);
    }

    private void OnDestroy()
    {
        _game.EntityCreated -= OnEntityCreated;
        _game.EntityRemoved -= OnEntityRemoved;
        _game.Started -= OnGameStart;
    }
    
    private void OnEntityCreated(object sender, IEntity entity)
    {
        bool isCreated = _viewBuilder.TryCreateView(entity, out GameObject view);
        if (isCreated)
            _instanceMap.Add(entity, view);
    }
    
    private void OnEntityRemoved(object sender, IEntity entity)
    {
        bool hasView = _instanceMap.TryGetValue(entity, out GameObject instance);
        if (hasView)
            Destroy(instance.gameObject);

        _instanceMap.Remove(entity);
    }
}