using UnityEngine;

/// <summary>
/// Clase hija de Entidad. Representa al personaje controlado por el jugador.
/// </summary>
public class Personaje : Entidad
{
    [Header("Atributos de Personaje")]
    [SerializeField] private float velocidad;
    [SerializeField] private float experiencia;

    private Rigidbody rb;

    protected override void Awake()
    {
        base.Awake(); // Inicializa vidaMaxima desde Entidad
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Mover();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Atacar();
        }
    }

    public void Mover()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 direccion = new Vector3(h, 0f, v) * velocidad * Time.deltaTime;
        transform.Translate(direccion, Space.World);
    }

    public void Saltar()
    {
        if (rb != null)
        {
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }

    public override void Atacar()
    {
        Debug.Log($"{nombre} ataca con {dano} de daño.");
        // Aquí iría la lógica de detección de enemigos cercanos, animación, etc.
    }

    public void GanarExperiencia(float cantidad)
    {
        experiencia += cantidad;
        Debug.Log($"{nombre} ganó {cantidad} de experiencia. Total: {experiencia}");
    }
}
