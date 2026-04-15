using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.Changed += SetValue;
    }

    private void Start()
    {
        _slider.value = (float)_health.CurrentHealth / _health.MaxAmount;
    }

    private void OnDisable()
    {
        _health.Changed -= SetValue;
    }
    
    private void SetValue(int current, int max)
    {
        _slider.value = (float)current / max;
    }
}
