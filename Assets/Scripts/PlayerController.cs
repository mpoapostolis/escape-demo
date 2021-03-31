using UnityEngine;

public class PlayerController : MonoBehaviour

{
    [SerializeField] private float speed = 2f;
    private readonly float _gravity = 9.81f;
    private Animator _anim;
    private CharacterController _controller;
    private bool _isRunning;

    // Start is called before the first frame update
    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var v = transform.forward * (speed * (_isRunning ? 2 : 1));

        if (Input.GetKeyDown(KeyCode.LeftShift)) _isRunning = true;
        if (Input.GetKeyUp(KeyCode.LeftShift)) _isRunning = false;
        if (Input.GetButtonDown("Fire1")) _anim.SetTrigger("Attack");

        if (horizontal != 0)
        {
            _walk();
            transform.Rotate(0, horizontal, 0, Space.Self);
        }

        if (vertical != 0)
        {
            _controller.Move(v * (vertical * Time.deltaTime));
            if (_isRunning) _run();
            else _walk();
        }
        else
        {
            _stayIdle();
        }

        v.y -= _gravity;
    }

    private void _run()
    {
        _anim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
    }

    private void _walk()
    {
        _anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void _stayIdle()
    {
        _anim.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
    }
}