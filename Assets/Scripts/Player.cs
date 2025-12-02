using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }
    public float JumpForce { get => jumpForce; private set => jumpForce = value; }
    public List<PowerUpBase> PowerUps { get; private set; }

    public bool IsInvulnerable { get; private set; }

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce;

    private Rigidbody2D rb;

    /// <summary>
    /// Encapsulate Move Speed
    /// </summary>
    /// <param name="moveSpeed"></param>
    public void SetMoveSpeed(float moveSpeed)
    {
        MoveSpeed = moveSpeed;
        Debug.Log($"[Player] MoveSpeed: {MoveSpeed}");
    }

    /// <summary>
    /// Encapsulate Invulnerability
    /// </summary>
    /// <param name="isInvulnerable"></param>
    public void SetInvulnerability(bool isInvulnerable)
    {
        IsInvulnerable = isInvulnerable;
        Debug.Log($"[Player] Invulnerability: {IsInvulnerable}");
    }

    /// <summary>
    /// Encapsulate Jump force
    /// </summary>
    /// <param name="jumpForce"></param>
    public void SetJumpForce(float jumpForce)
    {
        JumpForce = jumpForce;
        Debug.Log($"[Player] JumpForce: {JumpForce}");
    }


    /// <summary>
    /// Apply powerup and add it to Player.Powerups
    /// </summary>
    /// <param name="powerup"></param>
    public void ApplyPowerup(PowerUpBase powerup)
    {
        // Use polymorphism to apply different effects
        powerup.ApplyEffect(this);
        PowerUps.Add(powerup);
    }

    /// <summary>
    /// Clear Plalyer.Powerups and unapply their effects
    /// </summary>
    public void ClearPowerups()
    {
        foreach (var powerup in PowerUps)
        {
            powerup.UnapplyEffect(this);
        }

        PowerUps.Clear();
    }



    public void Move()
    {
        float input = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(input * MoveSpeed, rb.linearVelocityY);
    }

    public void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PowerUps = new List<PowerUpBase>();
    }

    private void Update()
    {
        Move();
        if (Input.GetKey(KeyCode.Space)) Jump();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out PowerUpBase powerup))
        {
            ApplyPowerup(powerup);
            Destroy(powerup.gameObject);
        }
    }
}
