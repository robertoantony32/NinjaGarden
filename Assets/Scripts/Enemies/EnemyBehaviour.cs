using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage = 1f;
    private Rigidbody2D rb;
    private Transform playerTransform;
    
    private Vector2 direction;
    private bool isCollidingWithPlayer;
    
    public bool IsCollidingWithPlayer
    {
        get => isCollidingWithPlayer;
    }
    public Vector2 Direction
    {
        get { return direction; }
    }

    private void Awake() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        TryGetComponent(out rb);
    }

    private void FixedUpdate() 
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (playerTransform == null) return;
        var difference = playerTransform.position - transform.position;

        direction = difference.normalized;

        rb.MovePosition(speed * Time.deltaTime * difference.normalized + (Vector3)rb.position);
    }

    private void OnCollisionStay2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthSystem>().TakeDamage(damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = false;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
