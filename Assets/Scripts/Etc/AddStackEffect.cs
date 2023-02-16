using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStackEffect : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    
    void Start()
    {
        Player.ActivateStackEffect += UseEffect;
    }
    public void UseEffect()
    {
        Instantiate(particle, transform.position, transform.rotation);
    }

    private void OnDestroy()
    {
        Player.ActivateStackEffect -= UseEffect;
    }
}
