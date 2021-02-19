using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private ObjectPool bulletPool;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private GameObject shootLocation;

    [SerializeField]
    private float bulletSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new ObjectPool(bulletPrefab, true, 50);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = bulletPool.GetObject();
            if(bullet)
            {
                bullet.transform.position = shootLocation.transform.position + transform.rotation * (Vector3.forward * 0.2f);
                bullet.GetComponent<Rigidbody>().velocity = transform.rotation * (Vector3.forward * bulletSpeed);
            }
        }
    }
}
