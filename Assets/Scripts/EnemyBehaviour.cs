using System;
using System.Collections.Generic ;
using UnityEngine;
using UnityEngine.AI;


public class EnemyBehaviour : MonoBehaviour
{
    private GameObject _player;

    private NavMeshAgent _navMesh;

    [SerializeField] Transform patrolRoute;

    private int _locationIndex = 0;

    private List<Transform> _locations;

    private int _lives;

    public int EnemyLives
    {
        get { return _lives; }
        private set
        {
            _lives = value;
            if (_lives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Player win");
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent<BulletBehaviour>(out var bullet))
        {
            EnemyLives -= 1;
            Debug.Log("Player popal");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerBehaviour>(out var player))
        {
            Debug.Log("Player voshel");
            _navMesh.SetDestination(_player.transform.position);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<PlayerBehaviour>(out var player))
        {
            Debug.Log("I see the player");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerBehaviour>(out var player))
        {
            Debug.Log("player vishel");
        }
    }

    private void Awake()
    {
        _locations = new List<Transform>();
        InitializePatrolRoute();
        
        _player = GameObject.FindWithTag("Player");

        _navMesh = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        MoveToNextPatrolLocation();
    }

    private void Update()
    {
        if (_navMesh.remainingDistance < 0.2f && !_navMesh.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }
    
    private void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            _locations.Add(child);
        }
    }
    private void MoveToNextPatrolLocation()
    {
        if (_locations.Count == 0)
        {
            return;
        }
        _navMesh.SetDestination(_locations[_locationIndex].position);
        _locationIndex = (_locationIndex + 1) % _locations.Count;
    }
}
