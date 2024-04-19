using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SoEnemie _stats;
    public float _life;
    public SpriteRenderer blinkSprite;
    private Material previousMaterial;
    void Start()
    {
        blinkSprite = GetComponent<SpriteRenderer>();
        previousMaterial = blinkSprite.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReceiveDamage(float damage)
    {

        _life = _stats.EnemyLife;
        _life -= damage;
        StartCoroutine(EffectDamage());
    }
    public IEnumerator EffectDamage()
    {
        blinkSprite.material = _stats.HitEffect;
        yield return new WaitForSeconds(0.2f);
        blinkSprite.material = previousMaterial;
        GameObject effect = Instantiate(_stats.DeathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(effect, .2f);
        
    }
}
