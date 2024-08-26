using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DefaultStats : MonoBehaviour
{
    [SerializeField] protected int cost;
    [SerializeField] protected float hp;
    [SerializeField] protected float def;
    [SerializeField] protected float atk;
    [SerializeField] protected float atkDelay;
    [SerializeField] protected float atkRange;
    [SerializeField] protected float speed;
    [SerializeField] protected float debuffEff;
    [SerializeField] protected float debuffRes;
    [SerializeField] protected int costDrop;

    public int Cost { get { return cost; } set { cost = value; } }
    public float Hp { get { return hp; } set { hp = value; } }
    public float Def { get { return def; } set { def = value; } }
    public float Atk { get { return atk; } set { atk = value; } }
    public float AtkRange { get { return atkRange; } set { atkRange = value; } }
    public float AtkDelay { get { return atkDelay; } set { atkDelay = value; } }
    public float Speed { get { return speed; } set { speed = value; } }
    public float DebuffEff { get { return debuffEff; } set { debuffEff = value; } }
    public float DebuffRes { get { return debuffRes; } set { debuffRes = value; } }
    public int CostDrop { get { return costDrop; } set { costDrop = value; } }
}
