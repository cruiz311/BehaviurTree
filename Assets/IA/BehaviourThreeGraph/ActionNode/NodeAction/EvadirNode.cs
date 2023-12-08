using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using System;

[TaskCategory("MyAI/Action")]

public class NodeEvadir : ActionNodeAction
{
    private float evasionThreshold = 0.5f; // Umbral de evasión (50% de salud)

    public override TaskStatus OnUpdate()
    {
        if (_IACharacterVehiculo != null && _IACharacterVehiculo.health != null)
        {
            float currentHealth = _IACharacterVehiculo.health.health;
            float maxHealth = _IACharacterVehiculo.health.healthMax;

            float healthPercentage = currentHealth / maxHealth;

            // Si la salud está por debajo del umbral de evasión, evadir
            if (healthPercentage < evasionThreshold)
            {
                // Coloca aquí la lógica de evasión, por ejemplo, moverse a un lugar seguro
                // Puedes llamar a funciones, activar comportamientos, etc.

                return TaskStatus.Success; // Devolver Success si se activa la evasión
            }
        }

        return TaskStatus.Failure; // Si no se cumple la condición, regresar Failure
    }
}
