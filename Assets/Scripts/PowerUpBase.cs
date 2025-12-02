using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    protected bool IsEffectActive;

    /// <summary>
    /// What happens when apply this effect to the player
    /// </summary>
    /// <param name="player"></param>
    public abstract void ApplyEffect(Player player);

    /// <summary>
    /// How to reverse the effect
    /// </summary>
    /// <param name="player"></param>
    public abstract void UnapplyEffect(Player player);
}
