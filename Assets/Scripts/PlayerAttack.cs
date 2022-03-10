using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMeleeAttack();
    }
    
    private void HandleMeleeAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            MeleeAttack();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            MeleeAttack2();
        }
    }

    private void MeleeAttack()
    {
        GetComponent<Animator>().SetTrigger("Attacking1");
    }
    private void MeleeAttack2()
    {
        GetComponent<Animator>().SetTrigger("Attacking2");
    }
}
