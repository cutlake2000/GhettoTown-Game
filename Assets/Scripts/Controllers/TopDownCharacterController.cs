using System;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;

    private float timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }

    protected CharacterStatsHandler Stats { get; private set; }

    private void Awake()
    {
        Stats = GetComponent<CharacterStatsHandler>();
    }

    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (Stats.currentStats.attackSO == null)
        {
            return;
        }

        if (timeSinceLastAttack <= Stats.currentStats.attackSO.delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }

        if (IsAttacking && timeSinceLastAttack > Stats.currentStats.attackSO.delay)
        {
            timeSinceLastAttack = 0;
            CallAttackEvent(Stats.currentStats.attackSO);
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }
}
