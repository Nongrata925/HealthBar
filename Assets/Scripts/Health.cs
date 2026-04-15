using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _max = 100;
    private int _minAmount;

    public int Current { get; private set; }
    
    public int Max => _max;
    
    public event Action<int, int> Changed;

    private void Awake()
    {
        Current = _max;
    }

    public void Decrease(int amount)
    {
        if (amount <= _minAmount)
        {
            return;
        }
        
        Current -= amount;

        if (Current <= _minAmount)
        {
            Current = _minAmount;
        }
        
        Changed?.Invoke(Current, _max);
    }

    public void Increase(int amount)
    {
        if (amount <= _minAmount)
        {
            return;
        }
        
        Current += amount;

        if (Current > _max)
        {
            Current = _max;
        }
        
        Changed?.Invoke(Current, _max);
    }
}
