using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hi : MonoBehaviour
{
    [SerializeField] private MeshRenderer g_plane;

    void Update()
    {
        g_plane.material.color = Color.red;
    }

}
