using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo : MonoBehaviour
{
    public bool isAmmo;
    public int AmmoAmount { get; set; }
    public int ammoAmount = 30;
    // Start is called before the first frame update
    void Start()
    {
        AmmoAmount = ammoAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
