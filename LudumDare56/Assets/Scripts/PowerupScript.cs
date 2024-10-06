using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    public MergeGunScript mergeGunScript;
    public UnmergeGunScript unmergeGunScript;
    // Start is called before the first frame update
    void Start()
    {
        mergeGunScript.enabled = false;
        unmergeGunScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EquipMergeGun()
    {
        mergeGunScript.enabled = true;
        unmergeGunScript.enabled = false;

    }
    public void EquipUnMergeGun()
    {
        mergeGunScript.enabled = false;
        unmergeGunScript.enabled = true;
    }
}
