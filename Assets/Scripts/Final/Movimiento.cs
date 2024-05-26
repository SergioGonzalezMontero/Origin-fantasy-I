using UnityEngine;

public enum Direccion
{
    Arriba,
    Abajo,
    Izquierda,
    Derecha
}

[System.Serializable]
public class Movimiento
{
    public Direccion direccion;

    [Space]

    [Range(0, 10)]
    public float velocidad;

    [Range(0, 10)]
    public float duracion;
    
    [Range(0, 10)]
    public float espera;
}
