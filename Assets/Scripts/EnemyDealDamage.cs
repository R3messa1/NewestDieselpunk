using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDealDamage : MonoBehaviour
{
    private Collider _hitBox;

    // Start is called before the first frame update
    void Start()
    {
        _hitBox = this.GetComponent<CapsuleCollider>();
        _hitBox.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();

            if(player != null)
            {
                player.TakeDamage(50f);
                _hitBox.isTrigger = false;
                StartCoroutine(AbleToDeal());
            }
        }
    }
    
    IEnumerator AbleToDeal()
    {
        yield return new WaitForSeconds(3);
        _hitBox.isTrigger = true;
    }
}
