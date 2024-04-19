using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDefault : MonoBehaviour
{
    public SoProjectile _stats;
    [HideInInspector]
    public float _lifeTime;
    [HideInInspector]
    public Vector2 _shootDirection;
    [HideInInspector]
    public GameObject _shootEffect;
    public float _speed;
    public GameObject parent;
    public void Awake()
    {
        GetReferences();
        Destroy(parent, _lifeTime);
        //
        SetDirection();
    }
    private void SetDirection()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * _speed);
    }

    public void GetReferences()
    {
        _speed = _stats.ProjectileSpeed;
        _lifeTime = _stats.ProjectileLifeTime;
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject Effect=Instantiate(_stats.ProjectileEffect, collision.transform.position, collision.transform.rotation);
            Destroy(Effect, .25f);
            Destroy(parent);
           
        }
        
    }
}
