using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    private int _maxHealth = 100;
    private int _minHealth = 0;

    public UnityAction<int> HealthChanged;

    public void Heal(int heal)
    {
        _health += heal;

        if (_health > _maxHealth)
            _health = _maxHealth;

        HealthChanged?.Invoke(_health);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health < _minHealth)
            _health = _minHealth;

        HealthChanged?.Invoke(_health);
    }
}
