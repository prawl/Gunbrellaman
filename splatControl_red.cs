using UnityEngine;
using System.Collections;

//Decompile by Si Borokokok

public class splatControl_red : MonoBehaviour
{
    public GameObject splatPrefab;
    public float timeToSplat = 0.4f;

    public void Main()
    {
    }

    public void makeSplat()
    {
        Object.Instantiate(splatPrefab, Vector3.zero, Quaternion.identity);
        Object.Instantiate(splatPrefab, Vector3.zero, Quaternion.identity);
        Invoke("makeSplat", timeToSplat);
    }

    public void Start()
    {
        makeSplat();
    }
}

