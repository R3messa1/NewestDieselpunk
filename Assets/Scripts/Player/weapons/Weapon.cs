﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] int damage = 25;
    [SerializeField] LayerMask ignoreLayer;
    
    public Animator _animator;

    [SerializeField]
    private GameObject _muzzleFlashPrefabLeft;

    [SerializeField]
    private int _maxAmmo = 100;
    [SerializeField]
    private int _startingAmmo = 20;
    private int _ammo;
    private bool _canFire = true;
    [SerializeField]
    private float _timeBetweenShots = 0.1f;
    private Player player;

    private void Start()
    {
        _muzzleFlashPrefabLeft.SetActive(false);
        _animator = this.GetComponent<Animator>();
        Player player = GameObject.Find("Player").GetComponent<Player>();
        _ammo = _startingAmmo;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetButton("Fire1") && _ammo > 0 && _canFire)
       { 
            _ammo -= 1;
            StartCoroutine(FireRate());
       }
       /*else if(Input.GetButtonUp("Fire1") || _ammo <= 0)
        {
            _muzzleFlashPrefabLeft.SetActive(false);
            _muzzleFlashPrefabRight.SetActive(false);
        }*/
        Debug.Log("ammo: " + _ammo);

        player.AmmoQuery(_ammo);

    }

    IEnumerator FireRate()
    {
        _canFire = false;
        _muzzleFlashPrefabLeft.SetActive(true);
        Shoot();
        yield return new WaitForSeconds(_timeBetweenShots);
        _canFire = true;
        _muzzleFlashPrefabLeft.SetActive(false);
    }

    void sound()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SoundManager.sndMan.PlayGunSound();
        }

       if (Input.GetButtonDown("Fire1"))
        { 
            Shoot();          
        } 

    }

private void Shoot()
    {
        _muzzleFlashPrefabLeft.SetActive(true);
        //sound();

        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range, ignoreLayer))
        {
            Debug.Log("Kuole saatanan " + hit.transform.name);
            Poll targetPol = hit.transform.GetComponent<Poll>();
            if (targetPol)
                targetPol.Hit();
            //TODO: add some hit effect for visual players
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            // call a method on EnemyHealth that decreases the enemy's health
            Debug.Log("Damaging this soB");
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }
}
