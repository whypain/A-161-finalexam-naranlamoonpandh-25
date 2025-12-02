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

    public void SetJumpForce(float jumpForce)
    {
        JumpForce = jumpForce;
        Debug.Log($"[Player] JumpForce: {JumpForce}");
    }

    public void ApplyPowerup(PowerUpBase powerup)
    {
        powerup.ApplyEffect(this);
        PowerUps.Add(powerup);
    }

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

    }

    public void Jump()
    {

    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PowerUps = new List<PowerUpBase>();
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
        if(collision.gameObject.TryGetComponent(out PowerUpBase powerup))
        {
            ApplyPowerup(powerup);
            Destroy(powerup.gameObject);
        }
    }
}
