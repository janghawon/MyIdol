using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class DataSender : MonoBehaviour
{
    [SerializeField] private int _phaseCount;
    [SerializeField] private int _syntexCount;

    [SerializeField] private TextAsset[] _dialogueArr;
    [SerializeField] private List<Dictionary<string, object>>[] Dialog_List_Arr = new List<Dictionary<string, object>>[1];

    SyntexManager _syntexManager;
    [SerializeField] private UnityEvent _phaseEndEvent = null;

    [field: SerializeField] public bool canPressPanel { get; set; }

    private void Awake()
    {
        _syntexManager = GetComponent<SyntexManager>();
    }

    private void Start()
    {
        for(int i = 0; i < _dialogueArr.Length; i++)
        {
            Dialog_List_Arr[i] = CSVReader.Read(_dialogueArr[i].name);
        }
        NextDataSend();
        canPressPanel = true;
    }

    public void NextDataSend()
    {
        _syntexManager.ChangeValue(Convert.ToInt32(Dialog_List_Arr[_phaseCount][_syntexCount]["Person"]),
                                   Convert.ToInt32(Dialog_List_Arr[_phaseCount][_syntexCount]["Name"]),
                                   Dialog_List_Arr[_phaseCount][_syntexCount]["Syntex"].ToString(),
                                   Dialog_List_Arr[_phaseCount][_syntexCount]["State"].ToString());
        _syntexCount++;
        if(Dialog_List_Arr[_phaseCount][_syntexCount]["Person"] == null)
        {
            _phaseEndEvent?.Invoke();
            _syntexCount = 0;
            _phaseCount++;
        }
    }
}
