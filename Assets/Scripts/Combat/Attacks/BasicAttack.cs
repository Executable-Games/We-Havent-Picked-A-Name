/// <summary>
/// Basic Attack
/// </summary>
/// Author: Sarah (GitHub: @skim74)
/// 2/14/16

public class BasicAttack : IAttack {
	/// <summary>
	/// Does 1hp damage
	/// </summary>
	public override float Damage {
		get { 
			return 1f;
		}
	}
	/// <summary>
	/// Hits 100% of the time
	/// </summary>
	public override float Accuracy {
		get { 
			return 1f;
		}
	}

	/// <summary>
	/// Displays "Basic Attack" at name of attack
	/// </summary>
	public override string DisplayName {
		get { 
			return "Basic Attack";
		}
	}
}
