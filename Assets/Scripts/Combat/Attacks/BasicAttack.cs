using UnityEngine;

/// <summary>
/// Basic Attack
/// </summary>
/// Author: Sarah (GitHub: @skim74)
/// 2/14/16 - Jordan (GitHub: @skorlir) - fixed properties and PerformAttack stub
///           Also add inherit from MonoBehaviour so can be used as Component
/// 2/14/16
public class BasicAttack : MonoBehaviour, IAttack {
    /// <summary>
    /// Private member infrastructure for properties
    /// </summary>
    private bool allowed;

    /// <summary>
    /// Does 1hp damage
    /// </summary>
    public float Damage {
        get { 
            return 1f;
        }
    }
    /// <summary>
    /// Hits 100% of the time
    /// </summary>
    public float Accuracy {
        get { 
            return 1f;
        }
    }

    /// <summary>
    /// Displays "Basic Attack" at name of attack
    /// </summary>
    public string DisplayName {
        get { 
            return "Basic Attack";
        }
    }

    /// <summary>
    /// Property getter and setter for Allowed
    /// </summary>
    public bool Allowed {
        get {
            return allowed;
        }
        set {
            allowed = value;
        }
    }

    /// <summary>
    /// Performs attack on target and returns change in health
    /// </summary>
    /// <param name="target">Unit to perform attack on</param>
    public float PerformAttack (Unit target) {
        // TODO(jordan): implement this
        return 0;
    }
}
