using UnityEngine;

public class SpeedBoost : PowerUpBase
{
    private float originalSpeed;


    public override void ApplyEffect(Player player)
    {
        if (IsEffectActive) return;

        originalSpeed = player.MoveSpeed;
        player.SetMoveSpeed(originalSpeed * 2f);
    }

    public override void UnapplyEffect(Player player)
    {
        player.SetMoveSpeed(originalSpeed);
        Debug.Log("[SpeedBoost] Cleared");
    }
}
