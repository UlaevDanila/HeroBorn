using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemBehaviour : MonoBehaviour
{
    private GameBehaviour _gameBehaviour;

    private void Awake()
    {
        _gameBehaviour = GameObject.Find("GameManager").GetComponent<GameBehaviour>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent<PlayerBehaviour>(out var player))
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Item collected");
            _gameBehaviour.ItemsCollected += 1;
        }
    }
    
}
