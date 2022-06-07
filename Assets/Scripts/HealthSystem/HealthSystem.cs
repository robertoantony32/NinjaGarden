using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] protected float maxLife;
    protected float life;

    protected virtual void Awake() 
    {
        life = maxLife;    
    }

    public virtual void TakeDamage(float damage)
    {
        if (life - damage <= 0)
        {
            life = 0f;
            Death();
        }
        else
        {
            life -= damage ;
        }
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }
}
