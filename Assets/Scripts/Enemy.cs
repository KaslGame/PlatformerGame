using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Vector2 _waypoint = new Vector2(5, -3);

    private void Start()
    {
        Move();
    }

    private void Move()
    {
        transform.DOMove(new Vector2(_waypoint.x, transform.position.y), 6).SetLoops(-1, LoopType.Yoyo);
    }
}
