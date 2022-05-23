using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinController : MonoBehaviour
{
    [SerializeField] private CoinView _coinView;
    [SerializeField] private CoinModel _model;

    public static event Action<CoinController> OnGameViewControllerCreated;

    void Awake()
    {
        if (_model == null)
        {
            _model = ScriptableObject.CreateInstance<CoinModel>();
        }
        OnGameViewControllerCreated += InitializeCoin;
    }
    public void Start()
    {
        Created(this);
    }

    void OnDestroy()
    {
        OnGameViewControllerCreated -= InitializeCoin;
    }

    public static void Created(CoinController coinController)
    {
        OnGameViewControllerCreated?.Invoke(coinController);
    }

    void InitializeCoin(CoinController coinController)
    {
        coinController.OnCreated(_model);
    }
    public void OnCreated(CoinModel model)
    {
        _coinView.OnCreated(model);
    }
    public void AddCoin()
    {
        _model.Coins.Value += 1;
    }
}
