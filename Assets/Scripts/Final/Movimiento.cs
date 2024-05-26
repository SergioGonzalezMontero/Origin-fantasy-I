using UnityEngine;

public enum Direccion
{
    Arriba,
    Abajo,
    Izquierda,
    Derecha
}

public enum Animacion
{
    M_Andar_Arriba,
    M_Andar_Abajo,
    M_Andar_Izquierda,
    M_Andar_Derecha,
    Parado_Arriba,
    Parado_Abajo,
    Parado_Izquierda,
    Parado_Derecha
}

[System.Serializable]
public class Movimiento
{
    public Direccion direccion;
    public Animacion animacion;

    [Space]

    [Range(0, 10)]
    public float velocidad;

    [Range(0, 10)]
    public float duracion;

    [Range(0, 10)]
    public float espera;
}
