using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerAim playerAim;

    private Animator animationController;

    private void Awake()
    {
        TryGetComponent(out animationController);
    }

    private void Update()
    {
        animationController.SetFloat("speed", _playerMovement.Direction.magnitude);
        animationController.SetFloat("dir_x", playerAim.Direction.x);
        animationController.SetFloat("dir_y", playerAim.Direction.y);
    }
}
