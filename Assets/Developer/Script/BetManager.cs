using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BetManager : MonoBehaviour
{
    public static BetManager instance;

    [SerializeField] float dem;
    [SerializeField] TMP_Text demText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        IncreaseBetValue();
        UpdateDemText();
    }

    public float GetCurrentDemValue()
    {
        return dem;
    }

    public void IncreaseBetValue()
    {
        float[] increments = { 1, 2, 3, 5, 10, 20, 30, 50, 75, 100, 200, 300, 400, 500, 1000, 3000, 5000, 10000, 20000, 30000 };

        for (int i = 0; i < increments.Length; i++)
        {
            if (dem < increments[i])
            {
                dem = increments[i];
                break;
            }
        }

        UpdateDemText();
    }

    public void DecreaseBetValue()
    {
        float[] decrements = { 30000, 20000, 10000, 5000, 3000, 1000, 500, 400, 300, 200, 100, 75, 50, 30, 20, 10, 5, 3, 2, 1 };

        for (int i = 0; i < decrements.Length; i++)
        {
            if (dem > decrements[i])
            {
                dem = decrements[i];
                break;
            }
        }

        UpdateDemText();
    }

    private void UpdateDemText()
    {
        demText.text = "DEM " + GetCurrentDemValue().ToString("#,##0.00", System.Globalization.CultureInfo.InvariantCulture);
    }

}
