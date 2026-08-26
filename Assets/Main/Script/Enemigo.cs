using UnityEngine;

/// <summary>
/// Clase hija de Entidad. Representa a un enemigo que persigue y ataca al jugador.
/// Se asocia con Trampa (no hereda de ella): un Enemigo puede activar una Trampa.
/// </summary>
public class Enemigo : Entidad
{
    [Header("Atributos de Enemigo")]
    [SerializeField] private float distancia; // rango de detección/ataque
    [SerializeField] private Transform objetivo; // normalmente el Personaje

    [Header("Asociación con Trampa")]
    [SerializeField] private Trampa trampaAsociada;

    private void Update()
    {
        if (objetivo == null) return;

        Perseguir();

        float distanciaActual = Vector3.Distance(transform.position, objetivo.position);
        if (distanciaActual <= distancia)
        {
            Atacar();
        }
    }

    public void Perseguir()
    {
        Vector3 direccion = (objetivo.position - transform.position).normalized;
        transform.position += direccion * 2f * Time.deltaTime;
    }

    // Sobrescribe el ataque genérico de Entidad con lógica propia de Enemigo
    public override void Atacar()
    {
        Debug.Log($"{nombre} ataca a {objetivo.name} con {dano} de daño.");

        // Ejemplo de asociación: el enemigo puede activar una trampa cercana
        if (trampaAsociada != null)
        {
            trampaAsociada.Activar();
        }
    }

    public void AsignarObjetivo(Transform nuevoObjetivo)
    {
        objetivo = nuevoObjetivo;
    }
}
