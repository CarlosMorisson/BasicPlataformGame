using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieControl : MonoBehaviour
{
    public SoEnemie _stats;
    private float _life;
    private float _damage;
    private Rigidbody2D _rig;
    private Animator anim;
    private void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _speed = _stats.EnemySpeed;
        _groundCheck = GetComponentInChildren<Transform>();
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        // Verifica se o inimigo está no chão
        isGrounded = Physics2D.OverlapCircle(_groundCheck.position, 0.1f, groundLayer);        // Move o inimigo
        Patrol();
    }

    
    #region Movimentacao
    private float _speed;
    [SerializeField]
    [Range(0,10)]
    private float _patrolDistance = 5.0f;
    [SerializeField]
    [Range(0, 10)]
    private float _groundCheckDistance = 5.0f;
    private Transform _groundCheck; 
    public LayerMask groundLayer;
    private bool isMovingRight = false; 
    private bool isGrounded = false;
    private float _distanceTraveled;
    void Patrol()
    {
        _distanceTraveled += Mathf.Abs(_rig.velocity.x) * Time.deltaTime;
        // Check for collisions with the ground layer in the X direction
        isGrounded = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y),
            new Vector2(_groundCheckDistance, _groundCheckDistance), 0f, groundLayer);
        if (isGrounded || _distanceTraveled >= _patrolDistance)
        {
            anim.CrossFade("Turn", 0);
            
        }
        _rig.velocity = new Vector3(_speed, 0);
    }
    private void ChangeDirection()
    {
        _distanceTraveled = 0f;
        anim.CrossFade("Idle", 1);
        isMovingRight = !isMovingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        _speed = -_speed;
        transform.localScale = scale;
    }


    #endregion

    #region Combat
    public void ReceiveDamage(float damage)
    {
        _life = _stats.EnemyLife;
        _life -= damage;
        Destroy(gameObject);
    }
    #endregion
}
