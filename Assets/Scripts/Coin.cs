using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    private Wallet _wallet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int oneCoin = 1;

        if (collision.TryGetComponent(out Movement _))
        {
            _wallet = collision.GetComponent<Wallet>();

            Destroy(gameObject);
            _wallet.AddMoney(oneCoin);
        }
    }
}
