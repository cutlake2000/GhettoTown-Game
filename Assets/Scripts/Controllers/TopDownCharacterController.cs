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

    protected virtual void Awake()
    {
        Stats = GetComponent<CharacterStatsHandler>();
    }

    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        Debug.Log("attackSO " + Stats.CurrentStats.attackSO);

        if (Stats.CurrentStats.attackSO == null)
        {
            return;
        }

        Debug.Log("delay " + Stats.CurrentStats.attackSO.delay);

        if (timeSinceLastAttack <= Stats.CurrentStats.attackSO.delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }

        if (IsAttacking && timeSinceLastAttack > Stats.CurrentStats.attackSO.delay)
        {
            timeSinceLastAttack = 0;
            CallAttackEvent(Stats.CurrentStats.attackSO);
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
