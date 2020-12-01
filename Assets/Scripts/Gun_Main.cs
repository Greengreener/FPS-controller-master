using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun_Main : MonoBehaviour
{
    public PlayerInfo player;
    /// <summary>
    /// The amount of damage each shot will do
    /// </summary>
    public float damage = 10f;
    /// <summary>
    /// The range that the gun can shoot to
    /// </summary>
    public float range = 100f;
    /// <summary>
    /// the amount of ammo in the clip
    /// </summary>
    [Header("Gun clip and ammo")]
    public int clip;
    /// <summary>
    /// the max amount of ammo in the clip at any one time
    /// </summary>
    public int clipMax = 30;
    /// <summary>
    /// the ammount of ammo in the revserve
    /// </summary>
    public int ammo;
    /// <summary>
    ///  the max amount of ammo in the reserve at any one point in time
    /// </summary>
    public int ammoMax = 100;

    /// <summary>
    /// the text element for displaying the clip amount
    /// </summary>
    [Header("UI details")]
    public Text clipText;
    /// <summary>
    /// the text element for displaying the reserver amount
    /// </summary>
    public Text ammoText;
    /// <summary>
    /// the name of this gun
    /// </summary>
    public string gunName;
    /// <summary>
    /// the text element to display the gun name
    /// </summary>
    public Text currentGun;

    /// <summary>
    /// refernce to the guns animator for conveying animations
    /// </summary>
    public Animator animator;

    /// <summary>
    /// the camera used for the player shooting
    /// </summary>
    public Camera fpsCamera;

    public bool animated;
    bool isFiring;
    void Start()
    {
        player = GetComponentInParent<PlayerInfo>();
        animator = GetComponent<Animator>();
        clip = clipMax;
        ammo = ammoMax;
        fpsCamera = GetComponentInParent<Camera>();
        gunName = "AK-47";
        currentGun.text = gunName;
        if (animated == true) animator = GetComponent<Animator>();
        UIUpdate();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && ammo > 0)
        {
            if (!animated) Reload();
        }
    }
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1") && clip > 0)
        {
            switch (animated)
            {
                case false:
                    Shoot();
                    break;
                case true:
                    animator.SetTrigger("Fire");
                    break;
            }
        }
        if (Input.GetButton("Fire1") && clip == 0)
        {
            Debug.Log("*click click click*");
        }
        //while (Input.GetButton)
    }

    /// <summary>
    /// Used to shoot the gun using rayscasts
    /// </summary>
    public void Shoot()
    {
        clip--;
        UIUpdate();
        RaycastHit hit;
        Health target;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            target = hit.transform.GetComponentInParent<Health>();

            if (target == null)
            {
                return;
            }

            Debug.Log(hit.ToString());
            if (target != null)
            {
                //target.TakeDamage(damage);
                player.GetComponent<PlayerCommands>().Damage(damage, target.gameObject.GetComponent<PlayerCommands>());
            }
            if (target.health <= 0)
            {
                Rigidbody rb = hit.rigidbody.GetComponent<Rigidbody>();
                rb.AddForceAtPosition((hit.point - fpsCamera.transform.position) * damage, hit.transform.position);
            }
            else
            {
                Debug.Log("Miss");
            }
        }
        else { Debug.Log("BigMiss"); }
    }
    void Reload()
    {
        int amountIntoClip;

        if (clip != clipMax)
        {
            amountIntoClip = clipMax - clip;
            if (ammo > 0)
            {
                if (amountIntoClip <= ammo)
                {
                    Debug.Log("Amount into clip = " + amountIntoClip);
                    clip = clip + amountIntoClip;
                    ammo = ammo - amountIntoClip;
                }
                else
                {
                    clip += ammo;
                    ammo = 0;
                }

            }
            if (ammo <= 0)
            {
                ammo = 0;
            }
        }
        UIUpdate();
    }
    void CheckShootingAvability()
    {
        if (Input.GetButton("Fire1") && clip > 0)
        {
            animator.SetTrigger("Fire");
        }

        if (Input.GetButton("Fire1") && clip == 0)
        {
            Debug.Log("*click click click*");
        }
    }
    /// <summary>
    /// Updates the UI elements 
    /// </summary>
    public void UIUpdate()
    {
        clipText.text = ("Clip: ") + clip;
        ammoText.text = ("Ammo: ") + ammo;
    }
}
