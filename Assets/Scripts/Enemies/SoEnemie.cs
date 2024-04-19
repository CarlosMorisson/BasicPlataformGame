using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SoEnemie : ScriptableObject
{
    public float EnemyLife;
    public float EnemySpeed;
    public float EnemyDamage;
    public GameObject DeathEffect;
    public GameObject Projectile;
    public Material HitEffect;

}
