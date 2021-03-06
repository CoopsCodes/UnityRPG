﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public string[] questMarkerNames;
    public bool[] questMarkersComplete;

    public static QuestManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        questMarkersComplete = new bool[questMarkerNames.Length];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(CheckIfComplete("Quest Test"));
            MarkQuestComplete("Quest Test");
            MarkQuestIncomplete("Fight the Demon");
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            SaveQuestData();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            LoadQuestData();
        }
    }

    public int GetQuestNumber(string questToFind) // matching the quest name to the right marker
    {

        for(int i = 0; i < questMarkerNames.Length; i++)
        {
            if(questMarkerNames[i] == questToFind)
            {
                return i;
            }
        }

        Debug.LogError("Quest '" + questToFind + "' not found");

        return 0; // if no quest is found we always return the first quest name, and the first quest is always blank.
        
    }

    public bool CheckIfComplete(string questToCheck) // checking if a quest is complete
    {
        if(GetQuestNumber(questToCheck) != 0) // checks the quest is valid (i.e not the empty quest 0)
        {
            return questMarkersComplete[GetQuestNumber(questToCheck)]; // this returns the value of the number at that location
        }

        return false;
    }

    public void MarkQuestComplete(string questToMark) // marking a quest as complete
    {
        questMarkersComplete[GetQuestNumber(questToMark)] = true;

        UpdateLocalQuestObjects();
    }

    public void MarkQuestIncomplete(string questIncomplete) // if a quest needs to marked as incomplete
    {
        questMarkersComplete[GetQuestNumber(questIncomplete)] = false;

        UpdateLocalQuestObjects();
    }

    public void UpdateLocalQuestObjects()
    {
        QuestObjectActivator[] questObjects = FindObjectsOfType<QuestObjectActivator>(); // locates all the Quest objects in the scene

        if (questObjects.Length > 0)
        {
            for(int i = 0; i < questObjects.Length; i++)
            {
                questObjects[i].CheckCompletion();
            }
        }
    }

    public void SaveQuestData()
    {
        for (int i = 0; i < questMarkerNames.Length; i++)
        {
            if (questMarkersComplete[i]) // this is saving the quest as complete or incomplete in the players game.
            {
                PlayerPrefs.SetInt("QuestMarker_" + questMarkerNames[i], 1);
            }
            else
            {
                PlayerPrefs.SetInt("QuestMarker_" + questMarkerNames[i], 0);
            }
        }
    }

    public void LoadQuestData()
    {
        for(int i = 0; i < questMarkerNames.Length; i++)
        {
            int valueToSet = 0; // default set to false
            if(PlayerPrefs.HasKey("QuestMarker_" + questMarkerNames[i]))
            {
                valueToSet = PlayerPrefs.GetInt("QuestMarker_" + questMarkerNames[i]);
            }

            if(valueToSet == 0)
            {
                questMarkersComplete[i] = false;
            }
            else
            {
                questMarkersComplete[i] = true;
            }
        }
    }
}
