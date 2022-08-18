using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    [SerializeField, Header("Mob")] private GameObject mob;
    class Node
    {
        float g = 0;
        float h = 0;
        float f = 0;
    }
    Node StartNode;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
