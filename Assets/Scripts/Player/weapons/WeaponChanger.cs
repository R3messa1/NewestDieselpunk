using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    public GameObject[] Weapons;
    int currWepInd = 0;
    // Update is called once per frame
    void Update()
    {
        float axis = Input.GetAxisRaw("CycleWeapon");
        Debug.Log(axis + " heo");
        int prevInd = currWepInd;
        if (axis > 0) 
            currWepInd = Mathf.Clamp(currWepInd + 1, 0, Weapons.Length - 1);
        if (axis < 0)
            currWepInd = Mathf.Clamp(currWepInd - 1, 0, Weapons.Length - 1);

        if (prevInd != currWepInd) {
            Weapons[currWepInd].SetActive(true);
            Weapons[prevInd].SetActive(false);
         }
    }
}
