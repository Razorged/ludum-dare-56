using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    public GameObject mergePowerup;
    public GameObject unmergePowerup;
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
        if(unmergeGunScript.enabled == true)
        {
            SpawnUnmergePowerup();
        }
        mergeGunScript.enabled = true;
        unmergeGunScript.enabled = false;

    }
    public void EquipUnMergeGun()
    {
        if(mergeGunScript.enabled == true)
        {
            SpawnMergePowerup();
        }
        mergeGunScript.enabled = false;
        unmergeGunScript.enabled = true;
    }

    private void SpawnMergePowerup()
    {
        mergePowerup.GetComponent<MergePowerupScript>().primed = false;
        Instantiate(mergePowerup, transform.position, Quaternion.identity);
    }
    private void SpawnUnmergePowerup()
    {
        unmergePowerup.GetComponent<UnmergePowerupScript>().primed = false;
        Instantiate(unmergePowerup, transform.position, Quaternion.identity);
    }
}
