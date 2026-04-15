using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class HealthBarViewer : MonoBehaviour
{
    [SerializeField] protected Health Health;
    
    protected Slider Slider;

    private void Awake()
    {
        Slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        Health.Changed += OnHealthChanged;
    }

    private void Start()
    {
        Slider.value = (float)Health.Current / Health.Max;
    }

    private void OnDisable()
    {
        Health.Changed -= OnHealthChanged;
    }
    
    protected abstract void OnHealthChanged(int current, int max);
}
