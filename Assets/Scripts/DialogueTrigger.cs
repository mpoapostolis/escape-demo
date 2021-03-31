using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private GameObject _dialogBox;
    private GameObject _hero;


    private void Start()
    {
        _hero = GameObject.FindGameObjectWithTag("Player");
        _dialogBox = GameObject.FindGameObjectWithTag("DialogBox");
    }

    private void Update()
    {
        transform.LookAt(_hero.transform.position);
        Debug.Log(transform.position);
        if (Vector3.Distance(_hero.transform.position, transform.position) < 1.8f)
        {
            _dialogBox.SetActive(true);
            TriggerDialog();
        }
        else
        {
            _dialogBox.SetActive(false);
        }
    }

    public void TriggerDialog()
    {
        FindObjectOfType<DialogueManager>().StartDialog(dialogue);
    }
}