/// <summary>
/// Interface for Attack Components
/// </summary>
/// Author: Jordan (GitHub: @skorlir)
/// 2/14/16 - return from abs class to interface using properties
/// 2/13/16
interface IAttack {
    /// <summary>
    /// Amount of Damage an Attack will do
    /// </summary>
    float Damage {
        get;
    }

    /// <summary>
    /// The Accuracy of an Attack
    /// </summary>
    float Accuracy {
        get;
    }

    /// <summary>
    /// What should be displayed on-screen as the name of the Attack
    /// </summary>
    string DisplayName {
        get;
    }

    /// <summary>
    /// Whether the Attack is currently allowed in combat
    /// </summary>
    bool Allowed {
        get;
        set;
    }

    /// <summary>
    /// Perform the Attack
    /// </summary>
    /// <param name="target">Unit the Attack will be performed on</param>
    /// <returns>The amount of damage done by the attack</returns>
    float PerformAttack (Unit target);
}
