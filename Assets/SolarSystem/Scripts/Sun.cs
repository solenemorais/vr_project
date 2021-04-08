using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public static Sun Instance; //static : modifie dans tous les objets, dans la classe mais pas dépendante des objets
    public float mass = 10;
    public Rigidbody rb;

    void Start()
    {
        Vector3 position = transform.position;
        Instance = this;
    }
}