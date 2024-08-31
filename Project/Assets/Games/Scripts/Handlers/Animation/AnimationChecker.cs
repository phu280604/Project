using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChecker : MonoBehaviour
{
    #region --- Method ---

    private void Update()
    {
        AnimationTimeChecker();
    }

    #region -- Animation time checker --
    public void AnimationTimeChecker()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime >= 1f)
        {
            ResetTimeAnimation("Upgrade");
            this.gameObject.SetActive(false);
        }
    }
    #endregion

    #region -- Reset time animation --
    public void ResetTimeAnimation(string name)
    {
        animator.Play(name, -1, 0);
    }
    #endregion

    #endregion

    #region --- Field ---

    [SerializeField] private Animator animator;

    #endregion
}
