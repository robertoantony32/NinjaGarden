using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private float deathTime = 2f;
    [SerializeField] private float damage = 1f;

    private void Start() {
        Invoke("Death", deathTime);
    }

    private void Update() {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<HealthSystem>().TakeDamage(damage);
            Death();
        }
    }
}
