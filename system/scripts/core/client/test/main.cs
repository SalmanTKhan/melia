//--- Melia Script ----------------------------------------------------------
// Testing Ground
//--- Description -----------------------------------------------------------
// Testing client scripts
//---------------------------------------------------------------------------

using Melia.Shared.Scripting;
using Melia.Zone.Events;
using Melia.Zone.Scripting;

public class TestClientScript : ClientScript
{
	public override void Load()
	{
		this.LoadAllScripts();
	}

	[On("PlayerReady")]
	protected void OnPlayerReady(object sender, PlayerEventArgs e)
	{
		this.SendAllScripts(e.Character);
	}
}
