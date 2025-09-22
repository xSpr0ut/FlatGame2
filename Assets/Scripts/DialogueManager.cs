using Ink.Parsed;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using UnityEditor.Rendering;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{

    private static DialogueManager instance;

    [Header("DialogueManager UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject playerObject;

    [Header("Choices UI")]

    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;


    private Ink.Runtime.Story currentStory;

    // to check if currently the dialogue is playing:
    // the get allows other things to access it but not chanege it
    public bool dialogueIsPlaying { get; private set; }


    private void Awake()
    {

       // DontDestroyOnLoad(gameObject);

        if (instance != null)
        {

            Debug.Log("MORE THAN ONE EXISTS THIS IS BAD BUT I DON'T KNOW WHY");

        }
        instance = this;


    }


    public static DialogueManager GetInstance()
    {

        return instance;


    }


    private void Start()
    {

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        // get all of the choices text
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

    }

    // logic for trasvering the ink story

    private void Update()
    {

        // return right away if there is no dialogue playing
        if (!dialogueIsPlaying)
        {
            return;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && dialogueIsPlaying)
        {
            ContinueStory();
        }

    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {

        // passes in our text file!
        currentStory = new Ink.Runtime.Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();

    }


    private IEnumerator ExitDialogueMode()
    {

        playerObject.transform.position = new Vector3(0, -3.5f, 0);
        yield return new WaitForSeconds(0.2f);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

    }

    private void ContinueStory()
    {

        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            // DisplayChoices();
        }
        else
        {
            Debug.Log("WHY DOES THIS HAPPEN TO MEEEEEEEE");
            StartCoroutine(ExitDialogueMode());
        }

    }

    /*

    // botched code?

    private void DisplayChoices()
    {

        List<Ink.Runtime.Choice> currentChoices = currentStory.currentChoices;

        // defensive check to make sure program runs
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were give than the UI can support. Number of choices given: " + currentChoices.Count);
        }

        int index = 0;
        // enable and initalize the choices
        foreach (Ink.Runtime.Choice choice in currentChoices)
        {

            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;

        }

        // go through the remaining choices the UI supports and make sure they're hidden
        for (int i = index; i < choices.Length; i++)
        {

            choices[i].gameObject.SetActive(false);

        }

        StartCoroutine(SelectFirstChoice());

    }


    private IEnumerator SelectFirstChoice()
    {

        // event system requires we clear it first
        // then wait for at least one frame before we set the current selected object
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);

    }



    // something weird about this function?
    public void MakeChoice(int choiceIndex)
    {

        currentStory.ChooseChoiceIndex(choiceIndex);

    }

    */



}
