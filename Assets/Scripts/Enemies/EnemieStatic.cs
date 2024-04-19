using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemieStatic : Enemy
{
    [SerializeField]
    private Transform RightScope, LeftScope;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void BackToEarth()
    {
        StartCoroutine(MoveYAxe());
    }

    public IEnumerator MoveYAxe()
    {
        transform.DOMoveY(transform.position.y - 1, 1);
        yield return new WaitForSeconds(3f);
        transform.DOMoveY(transform.position.y + 1, 1);
        anim.CrossFade("aa", 0);
        yield return new WaitForSeconds(1f);
        anim.CrossFade("Attack",0);
    }
    public void ShootRight()
    {
        Instantiate(_stats.Projectile, RightScope.transform.position, RightScope.transform.rotation, transform);
    }
    public void ShootLeft()
    {
        Instantiate(_stats.Projectile, LeftScope.transform.position, LeftScope.transform.rotation, transform);
    }
}
