using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Vault : MonoBehaviour
{
    public static Vault instance;
    [SerializeField] float caseMoneyValue;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (GameManager.instance.isTestBuild)
        {
            caseMoneyValue = 5000;
        }
    }

    public float SetCaseMoneyValue(float value)
    {
        return caseMoneyValue += value;
    }

    public float GetCurrentCaseValue()
    {
        return caseMoneyValue;
    }

}
