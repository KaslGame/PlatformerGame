using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _money;

    public event UnityAction<int> MoneyChanged;

    public int GetMoney()
    {
        return _money;
    }

    public void AddMoney(int money)
    {
        _money += money;
        MoneyChanged?.Invoke(money);
    }
}
