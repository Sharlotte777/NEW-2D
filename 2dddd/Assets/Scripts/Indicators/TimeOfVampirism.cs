using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeOfVampirism : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] protected Vampirism _vampirism;

    protected virtual void Awake()
    {
        UpdateValue();
    }

    protected void OnEnable()
    {
        _vampirism.AmountChanged += UpdateValue;
    }

    protected void OnDisable()
    {
        _vampirism.AmountChanged -= UpdateValue;
    }

    public void UpdateValue()
    {
        _text.SetText(_vampirism.RemainingTime.ToString());
    }
}
