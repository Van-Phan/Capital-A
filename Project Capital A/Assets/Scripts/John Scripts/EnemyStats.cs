using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private const float MAX_HEALTH = 3;
    public float currHealth;
    public float attackStat;
    public float defenseStat;
    public float speedStat;
    public float magicStat;
    public float mana;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = MAX_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
