using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health;
    public GameObject[] bodyParts = new GameObject[7];
    public GameObject box;

    private void Awake()
    {
        int i = 0;
        foreach (GameObject item in bodyParts)
        {
            Rigidbody part = bodyParts[i].GetComponent<Rigidbody>();
            //part.constraints = RigidbodyConstraints.FreezeAll;
            //part.useGravity = false;
            i++;
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            int i = 0;
            foreach (GameObject item in bodyParts)
            {
                Rigidbody part = bodyParts[i].GetComponent<Rigidbody>();
                part.constraints = RigidbodyConstraints.None;
                part.useGravity = true;
                i++;
            }
            Debug.Log("Killed");
            //Destroy(gameObject);
            if(box != null)
            {
                Rigidbody rbBox = box.GetComponent<Rigidbody>();
                rbBox.useGravity = true;
            }
        }
    }
}
