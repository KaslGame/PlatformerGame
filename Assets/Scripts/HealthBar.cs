using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private const string PlayerTag = "Player";

    private Slider _slider;
    private Player _player;
    private Coroutine _coroutine;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _player = GameObject.FindGameObjectWithTag(PlayerTag).GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnStateChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnStateChanged;
    }

    private void OnStateChanged(int healthChanged)
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
