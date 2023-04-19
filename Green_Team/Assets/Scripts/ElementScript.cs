using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ElementType {
    Fire,
    Mud,
    Clay,
}

class ElementScript : MonoBehaviour
{
    protected ElementType element;

    public ElementType Element {
        get { return element; }
        set { element = value; }
    }
}
