using System;
using System.Collections;
using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{
    [SerializeField] private float invencibleTime = 1f;
    private bool invencible;
    private HealthBar healthBar;

    private void Start()
    {
        healthBar = FindObjectOfType<HealthBar>();    
        healthBar.StartHealthBar(maxLife);
    }

    public override void TakeDamage(float damage)
    {
        if (invencible)
        {
            return;
        }

        base.TakeDamage(damage);

        healthBar.UpdateHealthBar(life);

        StartCoroutine(TurnVulnerable());
    }

    protected override void Death()
    {
        GameController.instance.ShowDeathPanel();
        base.Death();
    }

    private IEnumerator TurnVulnerable()
    {
        invencible = true;

        yield return new WaitForSeconds(invencibleTime);

        invencible = false;
    }
}
