using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 100;

    private int _maxHealth = 100;
    private int _minHealth = 0;

    public event UnityAction<int> HealthChanged;

    public void Heal(int heal)
    {
        _health = Mathf.Clamp(_health + heal, _minHealth, _maxHealth);

        HealthChanged?.Invoke(_health);
    }

    public void TakeDamage(int damage)
    {
        _health = Mathf.Clamp(_health - damage, _minHealth, _maxHealth);

        HealthChanged?.Invoke(_health);
    }
}
