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
        Debug.Log("攻撃された！");

        if (isDead) _Die();
        Debug.Log("うっつ、、、食らっちまった、、、！");
        return isDead;
    }

    private void _Die()
    {
        Debug.Log("死んでしまった。。。");
        Destroy(gameObject);
    }

}
