using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAnimationController : TopDownAnimations
{
    private static readonly int Attack = Animator.StringToHash("isAttacking");

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        controller.OnAttackEvent += Attacking;
    }

    private void Attacking(AttackSO sO)
    {
        animator.SetTrigger(Attack);
    }
}
