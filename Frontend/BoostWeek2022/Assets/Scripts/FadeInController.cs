using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInController : MonoBehaviour
{
    private Animator fadeAnimator;

    private void Awake()
    {
        fadeAnimator = GetComponent<Animator>();
    }

    public void FadeToWhite()
    {
        fadeAnimator.SetTrigger("FadeToWhite");
    }
}
