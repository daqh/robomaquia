using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (WeaponController))]
public class CharacterStats : MonoBehaviour
{
    private int attacks = 0;
    private int hits = 0;

    private int damage = 0;
    private float lifespan = 0;

    private WeaponController toolController;

    private void Start()
    {
        toolController = GetComponent<WeaponController>();
        toolController.OnUseTool += OnUseTool;
        toolController.OnHit += OnHit;
    }

    private void Update()
    {
        lifespan += Time.deltaTime;
    }

    private void OnUseTool()
    {
        attacks++;
    }

    private void OnHit(int damage)
    {
        this.damage += damage;
        hits++;
    }

    private void OnDestroy()
    {
        toolController.OnUseTool -= OnUseTool;
        toolController.OnHit -= OnHit;
    }

    public float Lifespan
    {
        get
        {
            return lifespan;
        }
    }

    public float Precision
    {
        get
        {
            return attacks > 0 ? hits / (float) attacks : 0;
        }
    }

    public int Damage {
        get {
            return damage;
        }
    }
}
