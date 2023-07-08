using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    [SerializeField] private GameObject kickPF;
    [SerializeField] private float duration;
    [Header("Cooldown")]
    [SerializeField] private float cooldown = 5f;
    private float cooldownTimer = 0f;

    private void Update()
    {
        if (cooldownTimer > 0)
            cooldownTimer -= Time.deltaTime;
    }

    public void Activate()
    {
        if (cooldownTimer <= 0)
        {
            StartCoroutine(SpawnKick());
            cooldownTimer = cooldown;
        }
    }


    IEnumerator SpawnKick()
    {
        GameObject kickGO = Instantiate(kickPF, transform);

        Animator animator = kickGO.GetComponent<Animator>();
        //if (animator) animator.Play("SpriteFade");

        yield return new WaitForSeconds(duration);

        Destroy(kickGO);
    }
}
