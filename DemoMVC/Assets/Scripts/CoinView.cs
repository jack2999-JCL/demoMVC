using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinView : MonoBehaviour
{
    private CoinModel _model;

    [SerializeField] private Text _text;

    public void OnCreated(CoinModel model)
    {
        _model = model;
        _model.Coins.OnValueChanged += OnCoinCountChanged;
        OnCoinCountChanged(_model.Coins.Value, _model.Coins.Value);
    }

    void OnDestroy()
    {
        _model.Coins.OnValueChanged -= OnCoinCountChanged;
    }

    void OnCoinCountChanged(int previous, int current)
    {
        _text.text = $"Coin: {current}";
    }
}