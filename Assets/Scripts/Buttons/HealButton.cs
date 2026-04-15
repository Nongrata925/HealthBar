using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class HealButton : BaseButton
{
    protected override void OnButtonClicked()
    {
        Health.Increase(Value);
    }
}
