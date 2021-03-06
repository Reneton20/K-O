using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text textDisplay;
    private string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject dialogPanel;
    public GameObject continueButton;

    private void Update()
    {
        if (dialogPanel.activeInHierarchy == true)
        {
            Time.timeScale = 0;
        }
        else if (dialogPanel.activeInHierarchy == false)
        {
            Time.timeScale = 1;
        }
    }

    private void Start()
    {
    }

    public void ShowDialog(string[] sentences)
    {
        Reset();
        this.sentences = sentences;
        dialogPanel.SetActive(true);
        StartCoroutine(Type());
    }

    void Reset()
    {
        this.sentences = null;
        textDisplay.text = "";
        index = 0;
        continueButton.SetActive(false);
        dialogPanel.SetActive(false);
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index])
        {
            textDisplay.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
        continueButton.SetActive(true);
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
            Reset();
    }
}
