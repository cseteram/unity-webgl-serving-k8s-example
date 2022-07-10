using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private BoundaryData _boundaryData;
    
    private EnemyData _enemyData;
    private Rigidbody2D _rigidbody2D;
    private Vector3 _destination;

    private void Start()
    {
        _enemyData = new EnemyData(15f);
        _rigidbody2D = GetComponent<Rigidbody2D>();

        var fromPosition = transform.position;
        var toPosition = _destination;
        var velocity = _enemyData.Speed * (toPosition - fromPosition).normalized;
        _rigidbody2D.velocity = velocity;
    }

    private void Update()
    {
        var pos = transform.position;
        var isInBoundary = (_boundaryData.xMin - 1 < pos.x && pos.x < _boundaryData.xMax + 1 &&
                            _boundaryData.yMin - 1 < pos.y && pos.y < _boundaryData.yMax + 1);
        
        if (isInBoundary == false)
        {
            Destroy(gameObject);
        }
    }

    public void SetDestination(Vector3 dst)
    {
        _destination = dst;
    }
}
