using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCommand : MonoBehaviour
{
    public void ChangeAnimation(string newAni)
    {
        if (curAni == newAni) return;

        animator.Play(newAni);
        curAni = newAni;
    }

    #region --- Field ---

    [SerializeField] private Animator animator;
    [SerializeField] private string curAni;

    #endregion
}
