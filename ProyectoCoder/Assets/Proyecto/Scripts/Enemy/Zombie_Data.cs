using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = "new Zombie Data", menuName = "Crear Zombie Data")]
public class Zombie_Data : ScriptableObject
{
    [SerializeField]
    [Range(0, 20)]
    private float speed;
    [SerializeField]
    [Range(0, 20)]
    private float DistanciaAtaque;
    [SerializeField]
    private int Peso;

    public float Speed { get => speed; set => speed = value; }
    public float DistanciaAtaque1 { get => DistanciaAtaque; set => DistanciaAtaque = value; }
    public int Peso1 { get => Peso; set => Peso = value; }
}
