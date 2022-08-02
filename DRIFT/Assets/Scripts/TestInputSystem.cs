using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInputSystem : MonoBehaviour
{
    private Transform _tr;

    private void Awake()
    {
        _tr = GetComponent<Transform>();
    }
    public void Chage_Gear()
    {
        Debug.Log("Next gear");
        Debug.Log(_tr);
        
    }
}
