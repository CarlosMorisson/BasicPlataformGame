using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerColliders : MonoBehaviour
{
    private Rigidbody2D rig;
    [SerializeField]
    private float jumpAfterKillEnemy;
    [SerializeField]
    private float jumpVelocity;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FallingPlataform"))
        {
            collision.gameObject.GetComponent<FallingPlataform>().StartFall();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("KillEnemy"))
        {
            transform.DOJump(new Vector3(transform.position.x, transform.position.y + jumpAfterKillEnemy, transform.position.z), jumpVelocity, 1, 0.3f);
            collision.gameObject.GetComponentInParent<EnemieControl>().ReceiveDamage(10);
        }
    }
}
