using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FallingPlataform : MonoBehaviour
{
    private Rigidbody2D rig;
    [SerializeField]
    [Range(0, 8)]
    private float fallDuration;
    [SerializeField]
    [Range(0, 1)]
    private float firstFall;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    public void StartFall()
    {
        transform.DOMoveY(transform.position.y - firstFall, .05f);
        StartCoroutine(Fall());
    }
    public IEnumerator Fall()
    {
        yield return new WaitForSeconds(0.5f);
        transform.DOMoveY(transform.position.y + firstFall / 2, .05f);
        yield return new WaitForSeconds(fallDuration);
        rig.gravityScale = 1;
        rig.constraints = RigidbodyConstraints2D.None;
    }
}