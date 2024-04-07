using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementHandler : MonoBehaviour
{
    public static UnityAction<bool> EnableCarMovement;
    [SerializeField] Transform player, car;

    void OnEnable()
    {
        EnableCarMovement += OnEnableCarMovement;
    }

    void OnDisable()
    {
        EnableCarMovement -= OnEnableCarMovement;
    }

    void Start()
    {
        OnEnableCarMovement(false);
    }

    private void OnEnableCarMovement(bool arg0)
    {
        car.gameObject.SetActive(arg0);
        player.gameObject.SetActive(!arg0);
    }
}
