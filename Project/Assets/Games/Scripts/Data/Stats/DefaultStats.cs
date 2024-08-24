using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DefaultStats : MonoBehaviour
{
    [SerializeField] protected int cost;
    [SerializeField] protected int hp;
    [SerializeField] protected int def;
    [SerializeField] protected int atk;
    [SerializeField] protected int atkSpeed;
    [SerializeField] protected int atkRange;
    [SerializeField] protected float speed;
    [SerializeField] protected int debuffEff;
    [SerializeField] protected int debuffRes;
    [SerializeField] protected int costDrop;

    public float Speed { get { return speed; } set { speed = value; } }
}
