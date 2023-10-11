using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private ProjectileManager projectileManager;
    private TopDownCharacterController topDownCharacterController;
    private Vector2 aimDirection = Vector2.right;
    public GameObject bulletPrefab;

    [SerializeField]
    private Transform projectileSpawnPosition;

    private void Awake()
    {
        topDownCharacterController = GetComponent<TopDownCharacterController>();
    }

    private void Start()
    {
        projectileManager = ProjectileManager.Instance;
        topDownCharacterController.OnAttackEvent += OnShoot;
    }

    private void OnShoot(AttackSO attackSO)
    {
        Debug.Log("Shoot");
        RangedAttackData rangedAttackData = attackSO as RangedAttackData;
        float projectileAngleSpace = rangedAttackData.multipleProjectilesAngle;
        int numberofProjectilePerShot = rangedAttackData.numberofProjectilesPerShot;

        float minAngle =
            numberofProjectilePerShot
            / 2f
            * projectileAngleSpace
            * 0.5f
            * rangedAttackData.multipleProjectilesAngle;

        for (int i = 0; i < numberofProjectilePerShot; i++)
        {
            float angle = minAngle + projectileAngleSpace * i;
            float randomSpread = UnityEngine.Random.Range(
                -rangedAttackData.spread,
                rangedAttackData.spread
            );
            angle += randomSpread;
            CreateProjectile(rangedAttackData, angle);
        }
    }

    private void CreateProjectile(RangedAttackData rangedAttackData, float angle)
    {
        projectileManager.ShootBullet(
            projectileSpawnPosition.position,
            RotateVector2(aimDirection, angle),
            rangedAttackData
        );
    }

    private static Vector2 RotateVector2(Vector2 v, float degree)
    {
        return Quaternion.Euler(0, 0, degree) * v;
    }
}
