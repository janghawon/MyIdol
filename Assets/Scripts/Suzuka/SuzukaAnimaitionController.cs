using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuzukaAnimaitionController : MonoBehaviour
{
    [SerializeField] private AnimatorOverrideController _animatior;
    private AnimationClip[] _stateClips = new AnimationClip[6];

    public void SetEmotionAnimation(SuzukaState ss)
    {
        _animatior["Embarass"] = _stateClips[(int)ss];
    }
}
