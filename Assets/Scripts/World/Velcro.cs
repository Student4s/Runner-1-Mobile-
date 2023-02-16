using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velcro : MonoBehaviour
{
    public delegate void ChangeStacks();

    public static event ChangeStacks ChangeStack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stackable"))
        {
            ChangeStack();
            //Debug.Log("Velcro!");
            other.transform.parent = transform;
        }
    }
}
