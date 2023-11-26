using Fusion;
using UnityEngine;

public class Movement : SimulationBehaviour
{
    public override void FixedUpdateNetwork()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(0,0,1);
        if(Input.GetKey(KeyCode.A))
            transform.Translate(-1,0,0);
        if(Input.GetKey(KeyCode.S))
            transform.Translate(0,0,-1);
        if(Input.GetKey(KeyCode.D))
            transform.Translate(1,0,0);
    }
}
