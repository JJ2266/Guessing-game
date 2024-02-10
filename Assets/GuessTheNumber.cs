using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.UI;
using UnityEngine.UI;

public class GuessTheNumber : MonoBehaviour
{
    [SerializeField] GameObject resetButton;
    [SerializeField] Button submitButton;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] GameObject WinText;
    [SerializeField] GameObject LoseText;
    [SerializeField] GameObject IncorrectText;
    [SerializeField] GameObject descriptionText;

    int number;
    int guessedNumber;
    int guessesLeft = 3;

    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }

    // Update is called once per frame
    void Update()
    {
        if (guessesLeft == 0)
        {
            
            LoseText.gameObject.SetActive(true);
            IncorrectText.gameObject.SetActive(false);
            inputField.interactable = false;
            submitButton.interactable = false;
        }

        if (inputField.text == "")
        {
            submitButton.interactable = false;
        }
        else if (inputField.text != "" && (guessedNumber != number) && guessesLeft != 0)
        {
            submitButton.interactable = true;
        }
    }
    public void GameSetup()
    {
        guessesLeft = 3;
        inputField.Select();
        inputField.text = "";
        number = Random.Range(1, 11);
        WinText.gameObject.SetActive(false);
        IncorrectText.gameObject.SetActive(false);
        LoseText.gameObject.SetActive(false);
        descriptionText.gameObject.SetActive(true);
        inputField.interactable = true;
        submitButton.interactable = true;

    }
    public void SubmitGuess()
    {
       guessedNumber = int.Parse(inputField.text);
       //player wins
        if(guessedNumber == number)
        {
            Debug.Log("you win");
            WinText.gameObject.SetActive(true);
            IncorrectText.gameObject.SetActive(false);
            descriptionText.gameObject.SetActive(false);
            inputField.interactable = false;
            submitButton.interactable = false;

        }
        //player loses
        else if (guessedNumber != number)
        {
            Debug.Log("you lose" + guessesLeft);
            IncorrectText.gameObject.SetActive(true);
            descriptionText.gameObject.SetActive(false);
            guessesLeft -= 1;
            IncorrectText.GetComponent<TMP_Text>().text = ("Incorrect! You have ") + (guessesLeft) + (" guesses left");
        }
    }
}
