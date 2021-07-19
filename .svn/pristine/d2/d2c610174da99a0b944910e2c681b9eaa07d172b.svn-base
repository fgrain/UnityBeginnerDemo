using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTrap : Arm
{
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.tag == Tag.Player)
        {
            other.GetComponent<Hurted>().IsSlowDown = true;
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        if (other.tag == Tag.Player)
        {
            other.GetComponent<Hurted>().IsSlowDown = false;
        }
    }
}
