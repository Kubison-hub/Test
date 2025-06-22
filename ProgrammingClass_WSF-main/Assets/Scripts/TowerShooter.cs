using UnityEngine;

public class TowerShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootInterval = 1f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootInterval)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}
