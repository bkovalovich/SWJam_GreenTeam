using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ElementType {
    Fire,
    Mud,
    Clay,
}

abstract class ElementScript : MonoBehaviour
{
    protected ElementType element;
}
