using UnityEngine;

public class ShieldBuff : PowerUpBase
{
    public override void ApplyEffect(Player player)
    {
        if (IsEffectActive) return;

        player.SetInvulnerability(true);
    }

    public override void UnapplyEffect(Player player)
    {
        player.SetInvulnerability(false);
        Debug.Log("[ShieldBuff] Cleared");
    }
}
