using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    [SerializeField] private float flashDuration = 1;
    public GameObject light;
    public ParticleSystem Gunshot;
    public float damage = 1f;
    [SerializeField] private float range;
    [SerializeField] private bool displayHitbox;
    [SerializeField] private GameObject hitbox_prefab;
    private Inventory_Scriot playerInventory;
    private float direction;

    private void Awake()
    {
         playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory_Scriot>();   
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            direction = transform.lossyScale.x / Mathf.Abs(transform.lossyScale.x);
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 VirtRight = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            if (transform.lossyScale.x > 0)
            {
                transform.right = VirtRight;
            }
            else
            {
                transform.right = -VirtRight;
            }
            if (Input.GetButtonDown("Fire1") && playerInventory.GetAmmo() > 0)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        playerInventory.SetAmmo(playerInventory.GetAmmo() - 1);
        Gunshot.Play();
        light.SetActive(true);
        Invoke("MuzzleFlash", flashDuration);
        

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right*direction, range);
        if (hit.collider != null)
        {
            if (hit.transform.tag == "Destructable")
            {
                try
                {
                    AudioClip soundEffect = hit.transform.GetComponent<AudioSource>().clip;
                    AudioSource.PlayClipAtPoint(soundEffect, hit.transform.position);
                }
                catch { }
                Health target = hit.transform.GetComponent<Health>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }
            else
            {
                Debug.Log(hit.transform.name);
            }

        }
    }

    public float GetDamage()
    {
        return damage;
    }
    public float SetDamage(float newDamage)
    {
        damage = newDamage;
        return damage;
    }

    void MuzzleFlash()
    {
        light.SetActive(false);
    }
}