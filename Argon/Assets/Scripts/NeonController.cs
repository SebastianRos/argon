using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NeonController : MonoBehaviour, NeonDriver {
    public Color Color { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool IsOn { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    [SerializeField]
    private NeonDriver[] managedNeons = new NeonDriver[0];

    public int[] bla = new int[0];

    public void updatedManagedNeons() {
        managedNeons = transform.GetComponentsInChildren<NeonDriver>();
    }
}
