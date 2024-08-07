using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleInteractable : MonoBehaviour, Interactable
{
    public void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
        // Add your interaction logic here
    }
}
