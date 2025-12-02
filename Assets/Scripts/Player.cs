using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }
    public float JumpForce { get => jumpForce; private set => jumpForce = value; }

    public bool IsInvulnerable { get; private set; }

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce;

    private Rigidbody2D rb;


    public void SetMoveSpeed(float moveSpeed)
    {
        MoveSpeed = moveSpeed;
        Debug.Log($"[Player] MoveSpeed: {MoveSpeed}");
    }

    public void SetInvulnerability(bool isInvulnerable)
    {
        IsInvulnerable = isInvulnerable;
        Debug.Log($"[Player] Invulnerability: {IsInvulnerable}");
    }



    public void Move()
    {

    }

    public void Jump()
    {

    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(input * MoveSpeed, rb.linearVelocityY);

        if (Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsInvulnerable) return;
    }
}

public abstract class PowerUpBase
{
    protected bool IsEffectActive;

    public abstract void ApplyEffect(Player player);
}


public class SpeedBoost : PowerUpBase
{
    public override void ApplyEffect(Player player)
    {
        throw new System.NotImplementedException();
    }
}

public class ShieldBuff : PowerUpBase
{
    public override void ApplyEffect(Player player)
    {
        throw new System.NotImplementedException();
    }
}

public class Milk : PowerUpBase
{
    public override void ApplyEffect(Player player)
    {
        throw new System.NotImplementedException();
    }
}