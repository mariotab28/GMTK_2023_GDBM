using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEffect : MonoBehaviour
{
    [SerializeField] GameObject hitEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(SpawnEffect());
    }

    IEnumerator SpawnEffect()
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        effect.transform.eulerAngles = new Vector3(0, 0, Random.value * 360);

        yield return new WaitForSeconds(0.5f);
        Animator animator = effect.GetComponent<Animator>();
        if (animator) animator.Play("SpriteFade");

        yield return new WaitForSeconds(1f);

        Destroy(effect);
    }
}
