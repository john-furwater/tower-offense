using UnityEngine;

public interface ICannonball
{
    bool IsPlayerOne { get; set; }

    void Launch(Transform parentTransform, float shotPower);
}
