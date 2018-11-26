using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonControl : MonoBehaviour {

    public bool pressed;
    
	void Start () {
        pressed = false;
	}
	
	void Update () {
        pressed = false;
	}

    void OnMouseUp()
    {
        pressed = true;
    }
}
