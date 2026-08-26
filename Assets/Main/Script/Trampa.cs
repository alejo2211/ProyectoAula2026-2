using UnityEngine;

/// <summary>
/// Clase independiente. No hereda de Entidad porque no es un ser vivo,
/// sino un objeto del entorno. Se asocia con Enemigo, que puede activarla.
/// </summary>
public class Trampa : MonoBehaviour
{
    [Header("Atributos de Trampa")]
    [SerializeField] private bool activa;
    [SerializeField] private float danoTrampa;
    [SerializeField] private float tiempo; // duración activa, en segundos

    public void Activar()
    {
        if (activa) return;

        activa = true;
        Debug.Log($"Trampa activada. Daño: {danoTrampa}");
        Invoke(nameof(Desactivar), tiempo);
    }

    public void Desactivar()
    {
        activa = false;
        Debug.Log("Trampa desactivada.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!activa) return;

        Entidad entidad = other.GetComponent<Entidad>();
        if (entidad != null)
        {
            entidad.RecibirDano(danoTrampa);
        }
    }
}
