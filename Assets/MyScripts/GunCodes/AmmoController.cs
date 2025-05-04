using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AmmoController : MonoBehaviour
{
    public int Damage = 1;
    
    private TargetController _target;
    private void OnTriggerEnter(Collider other)
    {
        _target = gameObject.transform.GetComponent<TargetController>();
        if (typeof(TargetController) != null) 
            _target.Damage(Damage);
    }

    private void OnTriggerExit(Collider other)
    {
        _target = gameObject.GetComponent<TargetController>();
        if (typeof(TargetController) != null)
            _target.Damage(Damage);
    }
}
