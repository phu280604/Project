using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    void Start()
    {
        Invoke("SeltDes", 2f);
    }

    public void SeltDes()
    {
        Destroy(gameObject);
    }
}
