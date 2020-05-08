﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField]
    private GameObject _GibPrefab;
    [SerializeField]
    private GameObject _ammoDrop;
    private GameObject HUD;

    [SerializeField]
    private float _TooWeakToFight = 20f;

    public void Start()
    {
        
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;

        if(hitPoints < _TooWeakToFight)
        {
            RichAI rAI = this.GetComponent<RichAI>();
            rAI.TooPrettyToDie();
        }

        if (hitPoints <= 0)
        {
            Destroy(gameObject);
            Instantiate(_GibPrefab, transform.position, transform.rotation);
            Instantiate(_ammoDrop, transform.position, _ammoDrop.transform.rotation);
            HUD = GameObject.Find("HUD");

            KillCounter _killcounter = HUD.GetComponent<KillCounter>();

            _killcounter.EnemyKilled();
        }
    }
}