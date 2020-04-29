using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivator : MonoBehaviour
{
    public string[] lines;

    private bool canActivate;

    public bool isPerson = true;

    public bool shoudlActivateQuest;
    public string questToMark;
    public bool markComplete;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canActivate && Input.GetButtonDown("Fire1") && !DialogManager.instance.dialogueBox.activeInHierarchy)
        {
            DialogManager.instance.ShowDialogue(lines, isPerson);

            DialogManager.instance.ShouldActivateQuest(questToMark, markComplete);
        }
    }

    // checks if player enters the trigger area, and activated the dialogue b ox
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            canActivate = true;
        }
    }

    // wont allow dialogue box to be repeatedly triggered if player is in area
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canActivate = false;
        }
    }
}
