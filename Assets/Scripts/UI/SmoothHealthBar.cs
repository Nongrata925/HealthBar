using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    
    private Slider _slider;

    private float _minValue = 0.0001f;
    private float _speedChange = 0.3f;
    
    private Coroutine _changeValue;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.Changed += ChangeHealth;
    }

    private void Start()
    {
        _slider.value = (float)_health.CurrentHealth / _health.MaxAmount;
    }

    private void OnDisable()
    {
        _health.Changed -= ChangeHealth;
    }
    
    private void ChangeHealth(int current, int max)
    {
        float target = (float)current / max;
        
        StopAnimateHealth();

        _changeValue = StartCoroutine(AnimateHealth(target));
    }

    private IEnumerator AnimateHealth(float target)
    {
        while (Mathf.Abs(_slider.value - target) > _minValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, _speedChange * Time.deltaTime);

            yield return null;
        }
        
        _slider.value = target;
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
