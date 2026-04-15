using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _maxAmount = 100;
    private int _minAmount;

    public int CurrentHealth { get; private set; }
    
    public int MaxAmount => _maxAmount;
    
    public event Action<int, int> Changed;

    private void Awake()
    {
        CurrentHealth = _maxAmount;
    }

    public void Decrease(int amount)
    {
        if (amount <= _minAmount)
        {
            return;
        }
        
        CurrentHealth -= amount;

        if (CurrentHealth <= _minAmount)
        {
            CurrentHealth = _minAmount;
        }
        
        Changed?.Invoke(CurrentHealth, _maxAmount);
    }

    public void Increase(int amount)
    {
        if (amount <= _minAmount)
        {
            return;
        }
        
        CurrentHealth += amount;

        if (CurrentHealth > _maxAmount)
        {
            CurrentHealth = _maxAmount;
        }
        
        Changed?.Invoke(CurrentHealth, _maxAmount);
    }
}
