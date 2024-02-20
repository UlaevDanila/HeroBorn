using System;
using UnityEngine;
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 75f;
    [SerializeField] private float jumpSpeed = 15f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float distanceToGround = 1.0f;

    private GameBehaviour _gameManager;

    private float _verticalInput;

    private float _horizontalInput;

    private Rigidbody _rigidbody;

    private CapsuleCollider _collider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehaviour>();
    }

    private void Update()
    {
        // 3
        _verticalInput = Input.GetAxis("Vertical") * moveSpeed;
        // 4
        _horizontalInput = Input.GetAxis("Horizontal") * rotationSpeed;
        // 5
        this.transform.Translate(Vector3.forward * _verticalInput *
                                 Time.deltaTime);
        // 6
        this.transform.Rotate(Vector3.up * _horizontalInput * 
                              Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Jump();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent<EnemyBehaviour>(out var player))
        {
            _gameManager.PlayerHealthPoint -= 1;
        }
    }

    private void Jump()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up*jumpSpeed, ForceMode.Impulse);
            Debug.Log("Govno");
        }
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom =
            new Vector3(_collider.bounds.center.x, _collider.bounds.min.y, _collider.bounds.center.z);

        bool grounded = Physics.CheckCapsule(_collider.bounds.center, capsuleBottom, distanceToGround,
            groundLayer, QueryTriggerInteraction.Ignore);

        return grounded;
    }

}
