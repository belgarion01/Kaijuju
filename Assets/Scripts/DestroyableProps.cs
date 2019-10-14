using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyableProps : Props, IHitable
{
    public int health;

    public UnityEvent OnDamageTaken;

    public virtual void OnHit(int damage)
    {
        TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        OnDamageTaken?.Invoke();

        if (health <= 0) Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
