using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _money;

    public int GetMoney()
    {
        return _money;
    }

    public void AddMoney(int money)
    {
        _money += money;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int oneCoin = 1;

        if (collision.TryGetComponent(out Coin _))
        {
            Destroy(collision.gameObject);
            AddMoney(oneCoin);
        }
    }
}
