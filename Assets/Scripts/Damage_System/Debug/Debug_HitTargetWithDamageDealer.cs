using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_HitTargetWithDamageDealer : MonoBehaviour
{
    public KeyCode hitKey = KeyCode.Space;

    [SerializeField] private DamageDealer damageDealer;
    [SerializeField] private BaseCharacterBehaviour characterBehaviour;
    private void Awake()
    {
#if !UNITY_EDITOR
        Destroy(gameObject);
#endif
    }
#if UNITY_EDITOR
    private void Start()
    {
        Debug.Log("Initial Char HP:" + characterBehaviour.GetHealth());
    }
    void Update()
    {
        if (Input.GetKeyDown(hitKey))
        {
            characterBehaviour.Damage(damageDealer);
            Debug.Log("Char HP:" + characterBehaviour.GetHealth());
        }
    }
#endif

}
