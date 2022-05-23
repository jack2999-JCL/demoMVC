using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinModel : ScriptableObject
{
    public ObservableVariable<int> Coins = new ObservableVariable<int>();
}

