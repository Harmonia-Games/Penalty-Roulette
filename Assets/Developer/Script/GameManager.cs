using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("General Stuff")]

    [SerializeField] GameObject insufficientBalanceUI;
    [SerializeField] GameObject[] hideBetUI;
    [SerializeField] Button[] GameButtons;
    bool isGameStart;

    [Header("Ball")]
    [SerializeField] Transform[] ballTarget;
    [SerializeField] Transform[] ballCurve;
    [SerializeField] int shootNumber;
    [SerializeField] Ball ball;


    private void Awake()
    {
        instance = this;
    }

    public void Play()
    {
        if (BetManager.instance.CurrentBet() <= BetManager.instance.GetCurrentCaseValue())
        {
            StartAction();
        }
        else
        {
            Debug.Log("You have insufficient balance");
            insufficientBalanceUI.SetActive(true);
        }
    }

    //StartAction
    private void StartAction()
    {
        isGameStart = true;
        InteractableGameButtons();
        Randomize();
    }
    private void InteractableGameButtons()
    {
        foreach (var item in GameButtons)
        {
            item.interactable = !isGameStart;
        }
        foreach (var item in hideBetUI)
        {
            item.SetActive(!isGameStart);
        }
    }
  

    //Randomize
    private void Randomize()
    {
        float randomValue = Random.value; // Get a random value between 0.0 and 1.0

        if (randomValue <= 0.5f)
        {
            // 50% chance for Save
            Debug.Log("Save");
            Goal();
        }
        else if (randomValue <= 0.8f)
        {
            // 30% chance for Miss
            Debug.Log("Miss");
            Goal();
        }
        else
        {
            // 20% chance for Goal
            Debug.Log("Goal");
            Goal();
        }
    }
    private void RandomizeShoot()
    {
        shootNumber = Random.Range(1, 24); 
    }

    //Actions
    private void Save()
    {
    }
    private void Miss()
    {

    }
    private void Goal()
    {
        RandomizeShoot();
        ball.gameObject.SetActive(true);
        ball.curvePosition = ballCurve[shootNumber];
        ball.targetPosition = ballTarget[shootNumber];
        ball.MoveWithCurve();
    }

   


}
