using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;
    private bool _isRunning;

    // Start is called before the first frame update
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) _isRunning = true;
        if (Input.GetKeyUp(KeyCode.LeftShift)) _isRunning = false;

        if (!_agent.hasPath && _anim.speed > 0) stayIdle();

        if (_agent.hasPath && _isRunning) run();
        else if (_agent.hasPath) walk();

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) _agent.SetDestination(hit.point);
        }
    }


    private void run()
    {
        _agent.speed = 5;
        _anim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
    }

    private void walk()
    {
        _agent.speed = 3f;
        _anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void stayIdle()
    {
        _anim.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
    }
}