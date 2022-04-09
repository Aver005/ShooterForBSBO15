using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Gun
{
    public string _Name { get; set; }
    public int _AmmoInMagazine { get; set; }
    public int _AmmoAll { get; set; }
    public float _BulletSpeed { get; set; }
    public float _Damage { get; set; }
    public int _ShootDelay { get; set; }


    public void Shoot();
    public void Reload();
}
