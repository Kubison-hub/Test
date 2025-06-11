using UnityEngine;

public class TowerShooter : MonoBehaviour
{
    public GameObject projectilePrefab;   // prefab pocisku
    public Transform firePoint;           // miejsce, z kt�rego startuje pocisk
    public float shootInterval = 1f;      // odst�p czasu mi�dzy strza�ami

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
