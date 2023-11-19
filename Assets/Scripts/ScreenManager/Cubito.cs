using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubito : MonoBehaviour
{
    void Update()
    {
        transform.position += Vector3.down * 1.5f * Time.deltaTime;
    }
}
