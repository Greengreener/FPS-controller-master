using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100;
    void Start()
    {
        health = 100;
    }
    public void TakeDamage(float _damage)
    {
        health -= _damage;
        print("Damaged by " + _damage);
        if (health <= 0f)
        {
            gameObject.SetActive(false);
            Debug.Log("Killed");
        }
    }
}
