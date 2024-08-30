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

    public void SetSpeed(float speed)
    {
        float speedAni = 1f / speed;
        animator.speed = speedAni;
    }

    #region --- Field ---

    [SerializeField] private Animator animator;
    [SerializeField] private string curAni;

    #endregion
}
