/// <summary>
/// Interface for Attack Components
/// </summary>
/// Author: Jordan (GitHub: @skorlir)
/// 2/13/16
abstract class IAttack {
    /// <summary>
    /// Amount of Damage an Attack will do
    /// </summary>
    public abstract float Damage {
        get;
    }

    /// <summary>
    /// The Accuracy of an Attack
    /// </summary>
    public abstract float Accuracy {
        get;
    }

    /// <summary>
    /// What should be displayed on-screen as the name of the Attack
    /// </summary>
    public abstract string DisplayName {
        get;
    }

    /// <summary>
    /// Whether the Attack is currently allowed in combat
    /// </summary>
    public bool Allowed = true;

    /// <summary>
    /// Set whether an Attack is currently allowed
    /// </summary>
    /// <param name="allowed">Value to set</param>
    abstract public void SetAllowed (bool allowed);

    /// <summary>
    /// Perform the Attack
    /// </summary>
    /// <param name="target">Unit the Attack will be performed on</param>
    /// <returns>The amount of damage done by the attack</returns>
    abstract public float PerformAttack (Unit target);
}
