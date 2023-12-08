using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using System;

[TaskCategory("MyAI/Action")]

public class NodeVerificarVidaCritica : ActionNodeAction
{
    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {

        if (_IACharacterVehiculo.health.health * 2 >= _IACharacterVehiculo.health.healthMax)
            return TaskStatus.Success;


        return TaskStatus.Failure;

        
    }
}
