using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITecnology 
{
    public int Amount { get; }
    public Vector3 Position { get; }

    public void Combine();
}
