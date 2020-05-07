using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField]
    private GameObject _GibPrefab;
    private GameObject HUD;

    public void Start()
    {
        
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
            //Instantiate(_GibPrefab, transform.position, _GibPrefab.transform.rotation);
            HUD = GameObject.Find("HUD");

            KillCounter _killcounter = HUD.GetComponent<KillCounter>();

            _killcounter.EnemyKilled();
        }
    }
}
