using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalProjectile : MonoBehaviour
{
    public enum PortalLeftOrRight
    {
        Left,
        Right
    };
    public PortalLeftOrRight portalProjectile;
    [SerializeField]
    private SoProjectile _stats;
    [SerializeField]
    private GameObject parent;
    private float _speed;
    private float _lifeTime;
    Vector2 _shootDirection;
    private GameObject _shootEffect;
    private Color _shootEffectColor;
    void Start()
    {
        GetReferences();
        Destroy(parent, _lifeTime);
        //
        SetDirection();
    }
    private void GetReferences()
    {
        _speed = _stats.ProjectileSpeed;
        _lifeTime = _stats.ProjectileLifeTime;
        switch (portalProjectile)
        {
            case PortalLeftOrRight.Left:
                _shootEffectColor = Color.red;
                break;
            case PortalLeftOrRight.Right:
                _shootEffectColor = Color.blue;
                break;

        }
    }
    private void SetDirection()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * _speed);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3) // Supondo que a camada 3 é a camada da superfície onde o projétil pode colidir
        {
            Vector2 contactPoint = collision.ClosestPoint(transform.position);

            // Pega a direção da colisão
            Vector2 contactDirection = (collision.transform.position - transform.position).normalized;

            // Calcula a rotação baseada na direção da colisão
            float angle = Mathf.Atan2(contactDirection.y, contactDirection.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Instancia o objeto adaptado à superfície
            Instantiate(_stats.ProjectileEffect, contactPoint, rotation);
        }
    }
}
