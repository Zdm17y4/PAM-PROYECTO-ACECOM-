using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemy : MonoBehaviour
{
    public enum EnemyState { Patrol, Ataque }

    public EnemyState currentState = EnemyState.Patrol;

    [Header("Movement Settings")]
    public float moveSpeed = 2f;
    public float raycastDistance = 1f;
    public LayerMask obstacleLayer;
    public float attackInterval = 8f;

    private Rigidbody2D rb2d;
    private Vector2 moveDirection;
    private float attackTimer;

    public BombController bombController;


    private bool isAttacking = false;

    private void Start()
    {
        bombController = GetComponent<BombController>();
        rb2d = GetComponent<Rigidbody2D>();
        DirrecionAleatoria();
        attackTimer = attackInterval;
    }

    private void Update()
    {
        switch (currentState)
        {
            case EnemyState.Patrol:
                EstadoPatrulla();
                break;

            case EnemyState.Ataque:
                EstadodeAtaque();
                break;
        }
    }

    private void EstadoPatrulla()
    {
        rb2d.velocity = moveDirection * moveSpeed;

        if (Obstaculo())
        {
            DirrecionAleatoria();
        }

        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0 && !isAttacking)
        {
            attackTimer = attackInterval;
            currentState = EnemyState.Ataque;
        }
    }

    private void EstadodeAtaque()
    {
        if (!isAttacking)
        {
            Debug.Log("En modo ataque");
            isAttacking = true;

            StartCoroutine(bombController.PlaceBomb());
            Debug.Log("bomba puesta");


            StartCoroutine(EjectucarMovimientoEscape());
        }
    }

    private IEnumerator EjectucarMovimientoEscape()
    {

        Vector2 PrimeraDireccion = ObtenerDirrecionAleatoria();
        while (!CaminoBloqueado(PrimeraDireccion))
        {

            rb2d.velocity = PrimeraDireccion * moveSpeed;
            yield return null;
        }

        rb2d.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.1f);


        Vector2 SegundaDireccion = DireccionPerpendicular(PrimeraDireccion);


        if (CaminoBloqueado(SegundaDireccion))
        {

            Vector2 DirrecionOpuesta = -SegundaDireccion;

            SegundaDireccion = DirrecionOpuesta;
        }



        while (!CaminoBloqueado(SegundaDireccion))
        {

            rb2d.velocity = SegundaDireccion * moveSpeed;
            yield return null;
        }


        rb2d.velocity = Vector2.zero;

        yield return Tiempo_espera(3f);
    }


    private IEnumerator Tiempo_espera(float waitTime)
    {
        rb2d.velocity = Vector2.zero;
        yield return new WaitForSeconds(waitTime);
        currentState = EnemyState.Patrol;
        isAttacking = false;
    }

    private Vector2 ObtenerDirrecionAleatoria()
    {
        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
        return directions[Random.Range(0, directions.Length)];
    }

    private Vector2 DireccionPerpendicular(Vector2 PrimeraDireccion)
    {
        if (PrimeraDireccion == Vector2.up || PrimeraDireccion == Vector2.down)
        {
            return Random.Range(0, 2) == 0 ? Vector2.left : Vector2.right;
        }
        else
        {
            return Random.Range(0, 2) == 0 ? Vector2.up : Vector2.down;
        }
    }

    private bool CaminoBloqueado(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, raycastDistance, obstacleLayer);
        Debug.DrawRay(transform.position, direction * raycastDistance, Color.red);
        return hit.collider != null;
    }



    private bool Obstaculo()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, raycastDistance, obstacleLayer);
        Debug.DrawRay(transform.position, moveDirection * raycastDistance, Color.red);
        return hit.collider != null;
    }

    private void DirrecionAleatoria()
    {
        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
        moveDirection = directions[Random.Range(0, directions.Length)];
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            Destroy(gameObject);

        }
    }
}