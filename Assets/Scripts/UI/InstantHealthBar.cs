public class InstantHealthBar : HealthBarViewer
{
    protected override void OnHealthChanged(int current, int max)
    {
        Slider.value = (float)current / max;
    }
}
