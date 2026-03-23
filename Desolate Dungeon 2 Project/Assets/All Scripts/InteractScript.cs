using System.Collections;
using UnityEngine;
using TMPro;



public class InteractScript : MonoBehaviour
{
    public GameObject DialoguePanel;
    public TextMesh DialogueText;
    public string[] Dialogue; 
    private int index;

    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (DialoguePanel.activeInHierarchy)
            {
                ZeroText();
            }
            else
            {
                DialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (DialogueText.text == Dialogue[index])
        {
            contButton.SetActive(true); 
        }
    }

    public void ZeroText()
    {
        DialogueText.text = " ";
        index = 0;
        DialoguePanel.SetActive(false);
    }
     IEnumerator Typing()
    {
        foreach (char letter in Dialogue[index].ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {

        contButton.SetActive(false);


        if(index < Dialogue.Length - 1)
        {
            index++;
            DialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ZeroText();
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            ZeroText();
        }
    }
}
