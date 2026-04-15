using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AttackButton : BaseButton
{
    protected override void OnButtonClicked()
    {
        Health.Decrease(Value);
    }
}
