using TMPro;
using UnityEngine;

public class HealthTextViewer : HealthBarViewer
{
    [SerializeField] private TextMeshProUGUI _text;
    
    private void Start()
    {
         _text.text = $"{Health.Current} / {Health.Max}";
    }

    protected override void OnHealthChanged(int current, int max)
    {
        _text.text = $"{current}/{max}";
    }
}
