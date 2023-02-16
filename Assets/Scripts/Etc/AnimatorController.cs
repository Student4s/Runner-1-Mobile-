using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator camShake;
    

    private void Start()
    {
        Velcro.ChangeStack += Shake;
    }

    public void Shake()
    {
        camShake.SetTrigger("shape");
        
    }
    
    private void OnDestroy()
    {
        Velcro.ChangeStack -= Shake;
    }
}
