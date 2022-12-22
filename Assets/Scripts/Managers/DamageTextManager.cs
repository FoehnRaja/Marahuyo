using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageTextManager : Singleton<DamageTextManager>
{
    public ObjectPooler Pooler { get; set; }


    void Start()
    {
        Pooler = GetComponent<ObjectPooler>();
    }


}
