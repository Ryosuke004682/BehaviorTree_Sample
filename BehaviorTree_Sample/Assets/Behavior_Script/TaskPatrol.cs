using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace BehaviorTree
{
    public class TaskPatrol : Node
    {
        private Transform _transform;
        private Transform[] _wayPoints;
        private int _currentWayPointIndex = 0;
        private float _speed = 2.0f;

        private float _waitTime  = 1.0f;
        private float _waitCount = 0.0f;
        private bool _waiting    = false;

        public TaskPatrol(Transform transform , Transform[] wayPoints)
        {
            _transform = transform;
            _wayPoints = wayPoints;
        }

        public override NodeState Evaluate()
        {
            if(_waiting)
            {
                _waitCount += Time.deltaTime;
                
                if(_waitCount >= _waitTime)
                {
                    _waiting = false;
                }
            }
            else
            {
                Transform wp = _wayPoints[_currentWayPointIndex];

                if (Vector3.Distance(_transform.position, wp.position) < 0.01f)
                {
                    _transform.position = wp.position;
                    _waitCount = 0f;
                    _waiting = true;

                    _currentWayPointIndex = (_currentWayPointIndex + 1) % _wayPoints.Length;
                }
                else
                {
                    _transform.position = Vector3.MoveTowards(_transform.position, wp.position, EnemysBT.speed * Time.deltaTime);
                    _transform.LookAt(wp.position);
                }
            }

            state = NodeState.RUNNING;
            return state;
          
        }
    }

}