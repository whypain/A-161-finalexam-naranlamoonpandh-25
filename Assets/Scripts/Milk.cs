using UnityEngine;

public class Milk : PowerUpBase
{
    public override void ApplyEffect(Player player)
    {
        if (IsEffectActive) return;

        player.ClearPowerups();
    }

    public override void UnapplyEffect(Player player)
    {
        Debug.Log("[Milk] Cleared");
    }
}