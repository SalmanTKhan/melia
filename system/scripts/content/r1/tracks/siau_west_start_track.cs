using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("SIAU_WEST_START_TRACK")]
public class SIAUWESTSTARTTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SIAU_WEST_START_TRACK");
		SetPropertyId("SIAUL_WEST_MEET_TITAS_TRACK");
		//SetMap("f_siauliai_west");
		//CenterPos(-575.51,260.83,-917.75);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-575.5098f, 260.8354f, -917.7501f));
		actors.Add(character);

		var npc0 = Shortcuts.AddNpc(0, 10020, "Sentinel", "f_siauliai_west", -589.3472, 260.8354, -822.1092, 0.416667);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var npc1 = Shortcuts.AddNpc(0, 10020, "Sentinel", "f_siauliai_west", -509.0249, 260.8354, -821.9139, 0);
		npc1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc1.AddEffect(new ScriptInvisibleEffect());
		npc1.Layer = character.Layer;
		actors.Add(npc1);

		var npc2 = Shortcuts.AddNpc(0, 20107, "Knight Titas", "f_siauliai_west", -595.9882, 260.8354, -714.5045, 0);
		npc2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc2.AddEffect(new ScriptInvisibleEffect());
		npc2.Layer = character.Layer;
		actors.Add(npc2);

		var npc3 = Shortcuts.AddNpc(0, 10020, "Sentinel", "f_siauliai_west", -621.8407, 260.8354, -759.7911, 0);
		npc3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc3.AddEffect(new ScriptInvisibleEffect());
		npc3.Layer = character.Layer;
		actors.Add(npc3);

		var npc4 = Shortcuts.AddNpc(0, 10020, "Sentinel", "f_siauliai_west", -620.8444, 260.8354, -704.7766, 0);
		npc4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc4.AddEffect(new ScriptInvisibleEffect());
		npc4.Layer = character.Layer;
		actors.Add(npc4);

		var npc5 = Shortcuts.AddNpc(0, 10033, "Sentinel", "f_siauliai_west", -647.3001, 260.8354, -949.1724, 1);
		npc5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc5.AddEffect(new ScriptInvisibleEffect());
		npc5.Layer = character.Layer;
		actors.Add(npc5);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 33:
				await track.Dialog.Msg("f_siauliai_west_dlg_9");
				break;
			case 34:
				await track.Dialog.Msg("SIAUL_WEST_MEET_TITAS_dlg3");
				break;
			case 35:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			case 63:
				//DRT_FUNC_ACT("SIAUL_WEST_MEET_TITAS_FUNC");
				character.AddonMessage(AddonMessage.DIALOG_SPACE_TUTORIAL);
				break;
			case 64:
				character.Tracks.End(this.TrackId);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}
}
