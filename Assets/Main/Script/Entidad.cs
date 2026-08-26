using UnityEngine;

/// <summary>
/// Clase base abstracta para todo elemento del juego que tenga vida y pueda atacar/recibir daño.
/// Personaje y Enemigo heredan de esta clase.
/// </summary>
public class Entidad : MonoBehaviour
{
    [Header("Atributos base")]
    [SerializeField] protected string nombre;
    [SerializeField] protected float vida;
    [SerializeField] protected float daño;

    protected float vidaMaxima;

    // Propiedades públicas de solo lectura para que otras clases consulten el estado
    public string Nombre => nombre;
    public float Vida => vida;
    public float Daño => daño;
    public bool EstaVivo => vida > 0f;

    protected virtual void Awake()
    {
        vidaMaxima = vida;
    }

    /// <summary>
    /// Aplica daño a la entidad. Es virtual para que las clases hijas
    /// puedan personalizar el comportamiento (ej. armadura, esquive, etc).
    /// </summary>
    public virtual void RecibirDano(float cantidad)
    {
        vida -= cantidad;
        vida = Mathf.Clamp(vida, 0f, vidaMaxima);

        Debug.Log($"{nombre} recibió {cantidad} de daño. Vida restante: {vida}");

        if (!EstaVivo)
        {
            Morir();
        }
    }

    /// <summary>
    /// Comportamiento de ataque genérico. Cada clase hija debe implementarlo
    /// según su propia lógica (Personaje ataca manualmente, Enemigo ataca al perseguir, etc).
    /// </summary>
  
    

    /// <summary>
    /// Comportamiento por defecto al morir. Puede sobrescribirse en las clases hijas.
    /// </summary>
    protected virtual void Morir()
    {
        Debug.Log($"{nombre} ha muerto.");
        gameObject.SetActive(false);
    }
}