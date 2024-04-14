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
        //Quaternion rotation = Quaternion.Euler(0, 0, transform.rotation.z);
       // _shootDirection = rotation * transform.right;
       // _shootDirection = _shootDirection.normalized;
        GetComponent<Rigidbody2D>().AddForce(transform.right * _speed);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
       
    }
}
