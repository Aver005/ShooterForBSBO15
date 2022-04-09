using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    private int _Ticks;
    [SerializeField] private int _DestroyTicks = 200;

    void Start()
    {
        _Ticks = 0;
    }

    void FixedUpdate()
    {
        if (_Ticks >= _DestroyTicks) { Destroy(gameObject); return; }
        _Ticks++;
    }
}
