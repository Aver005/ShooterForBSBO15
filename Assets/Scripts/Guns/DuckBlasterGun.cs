using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckBlasterGun : MonoBehaviour, Gun
{
    public string _Name { get; set; } = "Утка бластер";
    public int _AmmoInMagazine { get; set; } = 15;
    public int _AmmoAll { get; set; } = 60;
    public float _BulletSpeed { get; set; } = 2000f;
    public float _Damage { get; set; }
    public int _ShootDelay { get; set; } = 30;

    [SerializeField] private Transform _BulletHole;
    [SerializeField] private GameObject _BulletPrefab;

    private int _Ticks = 0;

    void Start()
    {
        
    }

    void Update()
    {
        Shoot();
        _Ticks++;

        if (_Ticks >= 120) { _Ticks = 0; }
    }

    public void Shoot()
    {
        if (Input.GetMouseButton(0) && _Ticks % _ShootDelay == 0 && _AmmoInMagazine > 0)
        {
            Vector3 bulletSpawn = _BulletHole.position;
            GameObject newBullet = Instantiate(_BulletPrefab, bulletSpawn, transform.rotation);
            Rigidbody rb = newBullet.GetComponent<Rigidbody>();
            rb.AddForce(_BulletSpeed * -transform.forward);
            _AmmoInMagazine--;
        }
    }

    public void Reload()
    {

    }
}
