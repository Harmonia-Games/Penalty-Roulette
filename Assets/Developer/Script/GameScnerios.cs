using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScnerios : MonoBehaviour
{
    [Header("Ball")]
    [SerializeField] GameObject[] missScenarios;
    [SerializeField] GameObject[] saveScenerios;
    [SerializeField] GameObject[] goalScenerios;
    [SerializeField] GameObject[] GoalKeepers;
    [SerializeField] int shootNumber;


    public void Play()
    {
        if (BetManager.instance.CurrentBet() <= Vault.instance.GetCurrentCaseValue())
        {
            StartAction();
            Vault.instance.SetCaseMoneyValue(-BetManager.instance.CurrentBet());
            UIManager.instance.UpdateMoneyTexts();
        }
        else
        {
            Debug.Log("You have insufficient balance");
            UIManager.instance.OpenInsufficientBalance(); //If you don't have enough money
        }
    }

    private void StartAction()
    {
        UIManager.instance.DisableInteractBetButtons();
        Randomize();
    }

    private void Randomize()
    {
        float randomValue = Random.value;

        if (randomValue <= GameManager.instance.chanceForGoal) Goal();
        else if (randomValue <= GameManager.instance.chanceForMiss) Miss();
        else Save();
    }

    private void RandomizeShoot()
    {
        shootNumber = Random.Range(1, 25);
    }

    private void ActivateRandomMissScenario()
    {
        int randomMissIndex = Random.Range(0, missScenarios.Length);
        missScenarios[randomMissIndex].SetActive(true);
    }

    private void ActivateRandomSaveScenario()
    {
        int randomMissIndex = Random.Range(0, saveScenerios.Length);
        saveScenerios[randomMissIndex].SetActive(true);
    }

    private void Save()
    {
        ActivateRandomSaveScenario();
        BetCalculate.instance.SaveBetCalculate();
    }

    private void Miss()
    {
        ActivateRandomMissScenario();
        BetCalculate.instance.MisBetCalculate();
    }

    private void Goal()
    {
        RandomizeShoot();
        goalScenerios[shootNumber - 1].SetActive(true);

        BetCalculate.instance.GoalBetCalculate(shootNumber);
    }


}
