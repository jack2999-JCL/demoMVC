using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable] public class ObservableVariable<T>
{
    [SerializeField]private T _value;
 
    public event Action<T, T> OnValueChanged;

    public T Value
    {
        get => _value;
        set
        {
            T previous = _value;
            _value = value;
            OnValueChanged?.Invoke(previous, _value);
        }
    }
}
