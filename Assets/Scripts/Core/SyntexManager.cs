using System.Collections;
using UnityEngine;
using System;
using System.Text;
using TMPro;
using UnityEngine.Events;

public class SyntexManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _sysntexText;
    [SerializeField] private TextMeshProUGUI _nameText;
    private StringBuilder _sb;
    private bool _canLook;
    private string[] _name = new string[2];
    SuzukaState _ss;
    [SerializeField] private UnityEvent<SuzukaState, bool> _SetEmotion = null;

    public void ChangeValue(int canLookSuzuka, int name, string syntex, string state)
    {
        _canLook = Convert.ToBoolean(canLookSuzuka);
        _ss = (SuzukaState)Enum.Parse(typeof(SuzukaState), state);
        SetLookInfo(name);
        TextingSyntex(syntex);
    }

    private void SetLookInfo(int num)
    {
        // setactive(canLook)
        _SetEmotion?.Invoke(_ss, _canLook);
        _nameText.text = _name[num];
    }

    IEnumerator TextingSyntex(string syntext)
    {
        for(int i = 0; i < syntext.Length; i++)
        {
            _sb.Append(syntext[i]);
            _sysntexText.text = _sb.ToString();
            yield return new WaitForSeconds(0.05f);
        }
    }
}
