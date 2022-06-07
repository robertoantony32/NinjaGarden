using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private EnemyBehaviour _enemyBehaviour;
    private Animator animationController;

    private void Awake()
    {
        TryGetComponent(out _enemyBehaviour);
        TryGetComponent(out animationController);
    }

    private void Update()
    {
        animationController.SetBool("isCollP", _enemyBehaviour.IsCollidingWithPlayer);
        animationController.SetFloat("dir_x", _enemyBehaviour.Direction.x);
        animationController.SetFloat("dir_y", _enemyBehaviour.Direction.y);
    }
}
