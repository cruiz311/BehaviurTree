using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class IACharacterVehiculo : IACharacterControl
{
    protected CalculateDiffuse _CalculateDiffuse;
    protected float speedRotation = 0;

    public float RangeWander;
    protected Vector3 positionWander;
    float FrameRate = 0;
    public float Rate = 4;

    public override void LoadComponent()
    {
        base.LoadComponent();
        _CalculateDiffuse = GetComponent<CalculateDiffuse>();
        positionWander = RandoWander(transform.position, RangeWander);
    }

    public virtual void LookEnemy()
    {
        if (AIEye.ViewEnemy == null) return;
        Vector3 dir = (AIEye.ViewEnemy.transform.position - transform.position).normalized;
        Quaternion rot = Quaternion.LookRotation(dir);
        rot.x = 0;
        rot.z = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * 50);
    }

    public virtual void LookPosition(Vector3 position)
    {
        Vector3 dir = (position - transform.position).normalized;
        Quaternion rot = Quaternion.LookRotation(dir);
        rot.x = 0;
        rot.z = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * speedRotation);
    }

    public virtual void LookRotationCollider()
    {
        if (_CalculateDiffuse.Collider)
        {
            speedRotation = _CalculateDiffuse.speedRotation;
            Vector3 posNormal = _CalculateDiffuse.hit.point + _CalculateDiffuse.hit.normal * 2;
            LookPosition(posNormal);
        }
    }

    public virtual void MoveToPosition(Vector3 pos)
    {
        agent.SetDestination(pos);
    }

    public virtual void MoveToEnemy()
    {
        if (AIEye.ViewEnemy == null) return;
        MoveToPosition(AIEye.ViewEnemy.transform.position);
    }

    public virtual void MoveToAllied()
    {
        //if (AIEye.ViewAllie == null) return;
        //MoveToPosition(AIEye.ViewAllie.transform.position);
    }

    public virtual void MoveToEvadEnemy()
    {
        if (AIEye.ViewEnemy == null) return;
        Vector3 dir = (transform.position - AIEye.ViewEnemy.transform.position).normalized;
        Vector3 newPosition = transform.position + dir * 5f;
        MoveToPosition(newPosition);
        LookPosition(newPosition);
    }

    Vector3 RandoWander(Vector3 position, float range)
    {
        Vector3 randP = Random.insideUnitSphere * range;
        randP.y = position.y; // Mantener la misma altura que la posición original
        return position + randP;
    }

    public virtual void MoveToWander()
    {
        if (AIEye.ViewEnemy != null) return;

        // Verificar si ya alcanzó la posición anterior de wander
        float distance = (transform.position - positionWander).magnitude;
        if (distance < 2)
        {
            // Obtener una nueva posición aleatoria dentro del rango
            if (!RandomPoint(transform.position, RangeWander, out positionWander))
            {
                // Si no se encuentra un punto aleatorio válido, detener el movimiento.
                return;
            }
        }
        positionWander.y = 0;
        // Mover hacia la posición wander actual y mirar en esa dirección
        MoveToPosition(positionWander);
        LookPosition(positionWander);
    }

    public bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = positionWander;
        return false;
    }
}
