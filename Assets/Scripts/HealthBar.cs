using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Slider _slider;
    private Coroutine _coroutine;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int healthChanged)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeHealthView(healthChanged));
    }

    private IEnumerator ChangeHealthView(int health)
    {
        float fluencyHealth = 0.05f;

        while (_slider.value != health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, Time.deltaTime / fluencyHealth);

            yield return null;
        }
    }
}
