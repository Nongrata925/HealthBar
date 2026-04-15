using System.Collections;
using UnityEngine;

public class SmoothHealthBar : HealthBarViewer
{
    private float _minValue = 0.0001f;
    private float _speedChange = 0.3f;
    
    private Coroutine _changeValue;
    
    protected override void OnHealthChanged(int current, int max)
    {
        float target = (float)current / max;
        
        StopAnimateHealth();

        _changeValue = StartCoroutine(AnimateHealth(target));
    }
    
    private IEnumerator AnimateHealth(float target)
    {
        while (Mathf.Abs(Slider.value - target) > _minValue)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, target, _speedChange * Time.deltaTime);

            yield return null;
        }
        
        Slider.value = target;
        _changeValue = null;
    }
    
    private void StopAnimateHealth()
    {
        if (_changeValue != null)
        {
            StopCoroutine(_changeValue);
            _changeValue = null;
        }
    }
}
