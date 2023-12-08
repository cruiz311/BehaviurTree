using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using System;

[TaskCategory("MyAI/Action")]

public class NodeEvadir : ActionNodeAction
{
    private float evasionThreshold = 0.5f; // Umbral de evasi�n (50% de salud)

    public override TaskStatus OnUpdate()
    {
        if (_IACharacterVehiculo != null && _IACharacterVehiculo.health != null)
        {
            float currentHealth = _IACharacterVehiculo.health.health;
            float maxHealth = _IACharacterVehiculo.health.healthMax;

            float healthPercentage = currentHealth / maxHealth;

            // Si la salud est� por debajo del umbral de evasi�n, evadir
            if (healthPercentage < evasionThreshold)
            {
                // Coloca aqu� la l�gica de evasi�n, por ejemplo, moverse a un lugar seguro
                // Puedes llamar a funciones, activar comportamientos, etc.

                return TaskStatus.Success; // Devolver Success si se activa la evasi�n
            }
        }

        return TaskStatus.Failure; // Si no se cumple la condici�n, regresar Failure
    }
}
