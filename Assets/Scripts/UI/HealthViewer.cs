using TMPro;
using UnityEngine;

public class HealthViewer : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _health.Changed += SetValue;
    }

    private void Start()
    {
        _text.text = $"{_health.CurrentHealth} / {_health.MaxAmount}";
    }

    private void OnDisable()
    {
        _health.Changed -= SetValue;
    }

    private void SetValue(int current, int max)
    {
        _text.text = $"{current}/{max}";
    }
}
