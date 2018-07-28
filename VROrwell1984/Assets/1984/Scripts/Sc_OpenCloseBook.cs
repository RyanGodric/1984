using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
    Nicht in Verwendung. Dieses Script regelt lediglich, welche Animation eines Objektes gespielt werden soll.
     */

public class Sc_OpenCloseBook : MonoBehaviour {
    private bool isOpen = false;
    public Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ChangeBookAnim()
    {
        if (isOpen)
            anim.Play("CloseBook");
        else
            anim.Play("OpenBook");
        isOpen = !isOpen;
    }
}
