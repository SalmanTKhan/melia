namespace Melia.Shared.Game.Const
{
	/// <summary>
	/// Defines a NPC's state.
	/// </summary>
	public enum NpcState
	{
		/// <summary>
		/// As a buffer state between used states listed below
		/// </summary>
		IgnoreState = -2,

		/// <summary>
		/// Used for opened chests, when they disappear.
		/// </summary>
		Invisible = -1,

		/// <summary>
		/// Presumed default state.
		/// </summary>
		Normal = 0,

		/// <summary>
		/// Make's NPC visible on the minimap
		/// </summary>
		Highlighted = 1,
	}
}
