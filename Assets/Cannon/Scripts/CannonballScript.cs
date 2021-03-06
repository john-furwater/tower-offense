﻿using UnityEngine;

public class CannonballScript : MonoBehaviour, ICannonball
{
    public bool IsPlayerOne { get; set; }

    public int Damage { get; set; } = 10;

    public virtual void Launch(Transform parentTransform, float shotPower) 
    {
        var cannonball = Instantiate(gameObject, parentTransform.position, Quaternion.identity);

        cannonball.GetComponent<CannonballScript>().IsPlayerOne = IsPlayerOne;
        cannonball.GetComponent<Rigidbody2D>().velocity = parentTransform.right * shotPower;
    }

    public void Explode()
    {
        Destroy(gameObject);
    }
}
