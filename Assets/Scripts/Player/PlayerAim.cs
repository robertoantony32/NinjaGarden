using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gunCannel;
    [SerializeField] private float cantShootTime = 1.5f;
    [SerializeField] private int maxShoots = 3;
    [SerializeField] private float fireRate = 0.3f;
    private PlayerInput playerInput;
    private Vector2 mousePos;
    private Camera camera;
    private Vector3 direction;
    
    private int shootAmount = 0;
        
    public Vector3 Direction
    {
        get { return direction; }
    }

    private bool isShooting;
    private bool isOutDelay = true;
    private bool isOnCooldown;

    private void Awake() {
        playerInput = new PlayerInput();

        playerInput.Player.Aim.performed += ctx => mousePos = ctx.ReadValue<Vector2>();
        playerInput.Player.Shoot.started += _ => isShooting = true;
        playerInput.Player.Shoot.canceled += _ => isShooting = false;
        camera = Camera.main;
    }

    private void OnEnable() {
        playerInput.Enable();
    }

    private void OnDisable() {
        playerInput.Disable();
    }

    private void Update()
    {
        AimMouse();
        Shoot();
    }

    private void AimMouse() 
    {
        var mouseWorldPos = camera.ScreenToWorldPoint(mousePos);

        var difference = mouseWorldPos - transform.position;

        direction = difference.normalized;

        var angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }

    private void Shoot()
    {
        if (!isShooting) return;
            
        if (shootAmount < maxShoots && isOutDelay)
        {
            Instantiate(bullet, gunCannel.position, transform.rotation);
            shootAmount++;
            StartCoroutine(ShootDelay());
        }else if (shootAmount >= maxShoots && !isOnCooldown)
        {
            StartCoroutine(CanShoot());
        }
    }

    private IEnumerator ShootDelay()
    {
        isOutDelay = false;
        yield return new WaitForSeconds(fireRate);
        isOutDelay = true;
    }
    
    private IEnumerator CanShoot()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cantShootTime);
        isOnCooldown = false;
        shootAmount = 0;
    }
}
