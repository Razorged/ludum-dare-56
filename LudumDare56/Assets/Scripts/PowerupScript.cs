using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] sounds;
    public GameObject mergePowerup;
    public GameObject unmergePowerup;
    public MergeGunScript mergeGunScript;
    public UnmergeGunScript unmergeGunScript;
    public LogicScript logicScript;
    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.Find("Logic Manager").GetComponent<LogicScript>();
        mergeGunScript.enabled = false;
        unmergeGunScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EquipMergeGun()
    {
        logicScript.script.setGlueGunActive();
        PlaySound();
        if (unmergeGunScript.enabled == true)
        {
            SpawnUnmergePowerup();
        }
        mergeGunScript.enabled = true;
        unmergeGunScript.enabled = false;

    }
    public void EquipUnMergeGun()
    {
        logicScript.script.setUnglueGunActive();
        PlaySound();
        if (mergeGunScript.enabled == true)
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

    private void PlaySound()
    {
        System.Random r = new System.Random();
        int rInt = r.Next(sounds.Length);
        audioSource.clip = sounds[rInt];
        audioSource.Play();
    }
}
