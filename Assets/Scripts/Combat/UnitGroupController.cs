using UnityEngine;
using System.Collections;
// NOTE(jordan): List
using System.Collections.Generic;
// NOTE(jordan): UnitsCollection
using UnitGroups;

/// <summary>
/// Unit Group Controller for handling groups of units
/// </summary>
/// Author: Jordan (GitHub: @skorlir)
/// 2/13/16 - enumerator
/// 2/11/16
public class UnitGroupController : MonoBehaviour {
    /// <summary>
    /// Enumerable list of Units
    /// </summary>
    public UnitsCollection Units = new UnitsCollection();

    void Start () {
        // NOTE(jordan): because Units are direct children, this is faster than
        //               GetComponentsInChildren<T>
        foreach (Transform child in transform) {
            Unit childUnit = child.gameObject.GetComponent<Unit>();
            Units.Add(childUnit);
        }
    }
}
