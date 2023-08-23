using System.Collections;
using UnityEngine;
using System;
using System.Text;
using TMPro;
using UnityEngine.Events;


public class SyntexManager : MonoBehaviour
{
    private string _syntex;
    bool isTexting;
    [SerializeField] private TextMeshProUGUI _sysntexText;
    [SerializeField] private TextMeshProUGUI _nameText;
    [NonSerialized] private GameObject _textPanel;
    private StringBuilder _sb;
    private bool _canLook;
    [SerializeField] private string[] _name = new string[2];
    SuzukaState _ss;
    [SerializeField] private UnityEvent<SuzukaState, bool> _SetEmotion = null;
    private Coroutine _textCo;

    private void Awake()
    {
        _sb = new StringBuilder();
    }

    public void ChangeValue(int canLookSuzuka, int name, string syntex, string state)
    {
        _canLook = Convert.ToBoolean(canLookSuzuka);
        _ss = (SuzukaState)Enum.Parse(typeof(SuzukaState), state);
        SetLookInfo(name);
        _textCo = StartCoroutine(TextingSyntex(syntex));
    }

    private void SetLookInfo(int num)
    {
        _SetEmotion?.Invoke(_ss, _canLook);
        _nameText.text = _name[num];
    }

    IEnumerator TextingSyntex(string syntext)
    {
        if(!isTexting)
        {
            _syntex = syntext;
            isTexting = true;
            _sb = new StringBuilder();
            for (int i = 0; i < _syntex.Length; i++)
            {
                _sb.Append(_syntex[i]);
                _sysntexText.text = _sb.ToString();
                yield return new WaitForSeconds(0.05f);
            }
            isTexting = false;
        }
        else
        {
            StopCoroutine(_textCo);
            _sysntexText.text = _syntex;
            isTexting = false;
        }
    }
}
