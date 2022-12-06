using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Tool
{

    [SerializeField]
    [Range(0, 100)]
    private int damage;

    [SerializeField]
    private Bullet bullet;

    public override event OnHitDelegate OnHit;

    public override void OnUse(Vector2 position) {
        transform.rotation = Quaternion.Euler(Vector3.right);
        Bullet _ = Instantiate(
            bullet,
            transform.position,
            Quaternion.identity
        );
        _.gameObject.transform.up = position - (Vector2)transform.position;
    }


}
