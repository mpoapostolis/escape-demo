using System;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueName;
    public TMP_Text dialogueDescription;




    public void StartDialog(Dialogue d)
    {
        dialogueName.text = d.name;
        dialogueDescription.text = d.description;
    }
}