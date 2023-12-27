using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public Projectile projectilePrefab;
    public float projectileSpeed = 10f;
    public Transform shootPoint;

    private float delay = .5f;
    private bool canShoot;

    private void Start()
    {
        canShoot = true;
    }

    void Update()
    {
        if (canShoot)
        {
            if (Input.GetMouseButtonDown(0)) // Left mouse button
            {
                canShoot = false;
                ShootProjectile();
            }
        }
        else
        {
            delay -= Time.deltaTime;
            if (delay <= 0f)
            {
                delay = .5f;
                canShoot = true;
            }
        }
    }

    void ShootProjectile()
    {
        // Get mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;

        // Convert screen coordinates to world coordinates
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Instantiate projectile at the shooting point
        GameObject projectile = Instantiate(projectilePrefab.gameObject, shootPoint.position, Quaternion.identity);

        // Calculate the direction to the mouse position
        Vector3 shootDirection = (targetPosition - transform.position).normalized;

        // Apply force to the projectile in the calculated direction
        projectile.GetComponent<Rigidbody2D>().velocity = projectileSpeed * shootDirection;
    }
}
