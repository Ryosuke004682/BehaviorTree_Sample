using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private int _healthPoints;

    private void Awake()
    {
        _healthPoints = 30;
    }
    
    public bool TaskHit()
    {
        _healthPoints -= 10;
        bool isDead = _healthPoints <= 0;
        Debug.Log("�U�����ꂽ�I");

        if (isDead) _Die();
        Debug.Log("�����A�A�A�H������܂����A�A�A�I");
        return isDead;
    }

    private void _Die()
    {
        Debug.Log("����ł��܂����B�B�B");
        Destroy(gameObject);
    }

}
