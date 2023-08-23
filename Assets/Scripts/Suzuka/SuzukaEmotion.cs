using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum SuzukaState
{
    Embrass,
    Nodding,
    Surprise,
    Dance_1,
    Dance_2,
    Dance_3,
    None
}

public class SuzukaEmotion : MonoBehaviour
{
    [SerializeField] private SuzukaState _suzukaState;
    [SerializeField] private UnityEvent<SuzukaState> _animationEvent;

    public void SetEmotion(SuzukaState suzukaState, bool canLook)
    {
        _suzukaState = suzukaState;
        _animationEvent?.Invoke(_suzukaState);
        Debug.Log(canLook);
        gameObject.SetActive(canLook);
    }
}
