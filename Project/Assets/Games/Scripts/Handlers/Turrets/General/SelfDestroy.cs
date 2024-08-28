using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    void Start()
    {
        Invoke("SeltDes", stats.AtkDelay);
    }

    public void SeltDes()
    {
        Destroy(gameObject);
    }

    [SerializeField] private StatsTurrets stats;
}
