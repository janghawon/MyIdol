using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuzukaAnimaitionController : MonoBehaviour
{
    [SerializeField] private AnimatorOverrideController _animatior;
    private Animator _controller;
    private AnimationClip[] _stateClips = new AnimationClip[6];

    private readonly int _emotionHash = Animator.StringToHash("isEmotion");

    private void Awake()
    {
        _controller = GetComponent<Animator>();
    }

    public void SetEmotionAnimation(SuzukaState ss)
    {
        if (ss == SuzukaState.None)
        {
            _controller.SetBool(_emotionHash, false);
            return;
        }
        
        _controller.SetBool(_emotionHash, true);
        _animatior["Embarass"] = _stateClips[(int)ss];
    }
}
