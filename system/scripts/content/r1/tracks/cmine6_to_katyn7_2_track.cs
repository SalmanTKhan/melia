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

[TrackScript("CMINE6_TO_KATYN7_2_TRACK")]
public class CMINE6TOKATYN72TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CMINE6_TO_KATYN7_2_TRACK");
		//SetMap("c_voodoo");
		//CenterPos(-43.00,0.00,18.01);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 20136, "", "c_voodoo", -22.82513, 0.01, 32.79485, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154040, "영상", "c_voodoo", -63.5525, 0.01, -19.94679, 10);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47234, "", "c_voodoo", -4.818863, 0.01, -4.234894, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 7:
				await track.Dialog.Msg("c_voodoo_dlg_1");
				break;
			case 22:
				break;
			case 28:
				break;
			case 36:
				await track.Dialog.Msg("c_voodoo_dlg_5");
				break;
			case 39:
				await track.Dialog.Msg("c_voodoo_dlg_6");
				break;
			case 42:
				await track.Dialog.Msg("c_voodoo_dlg_7");
				break;
			case 45:
				await track.Dialog.Msg("c_voodoo_dlg_8");
				break;
			case 49:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
