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
    private string _gameTag;
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
                _gameTag = "RedPortal";
                break;
            case PortalLeftOrRight.Right:
                _shootEffectColor = Color.blue;
                _gameTag = "BluePortal";    
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
            Vector2 directionToContact = contactPoint - (Vector2)transform.position;
            float angle = Mathf.Atan2(directionToContact.y, directionToContact.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, 0, angle+90);
            GameObject portal=Instantiate(_stats.ProjectileEffect, contactPoint, rotation);
            portal.GetComponent<SpriteRenderer>().color = _shootEffectColor;
            portal.gameObject.tag = _gameTag;
            PortalController.instance.GetNewPortal(portal, _gameTag);
            Destroy(gameObject);
        }
    }
}
