using UnityEngine;

public class DialogueTrigger: MonoBehaviour {
    public Dialogue dialogue;
    [SerializeField] private GameObject _dialogBox;
    private GameObject _hero;

    private bool isActive;


    private void Start() {
        _hero = GameObject.FindGameObjectWithTag("Player");
        _dialogBox.SetActive(false);
    }

    public void TriggerDialog() {
        FindObjectOfType<DialogueManager>().StartDialog(dialogue);
    }

    private void LateUpdate() {
        transform.LookAt(_hero.transform.position);
        isActive = Vector3.Distance(_hero.transform.position, transform.position) < 1.8f;
        if(isActive) {
            _dialogBox.SetActive(true);
            TriggerDialog();
        } else if(Vector3.Distance(_hero.transform.position, transform.position) < 3f) {
            _dialogBox.SetActive(false);
        }

    }

}