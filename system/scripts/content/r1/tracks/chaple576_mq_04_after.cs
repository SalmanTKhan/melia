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

[TrackScript("CHAPLE576_MQ_04_AFTER")]
public class CHAPLE576MQ04AFTER : TrackScript
{
	protected override void Load()
	{
		SetId("CHAPLE576_MQ_04_AFTER");
		//SetMap("d_chapel_57_6");
		//CenterPos(-1645.26,0.42,426.32);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 40069, "", "d_chapel_57_6", -1744.691, 0.4277, 426.1414, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147390, "", "d_chapel_57_6", -1880.05, -42.12668, 395.5993, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20026, "", "d_chapel_57_6", -1708.233, 0.4177, 404.9373, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		character.Movement.MoveTo(new Position(-1648.284f, 0.4177f, 419.046f));
		actors.Add(character);

		var mob3 = Shortcuts.AddMonster(0, 147379, "", "d_chapel_57_6", -1777.82, 0.4177, 425.8256, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 147399, "", "d_chapel_57_6", -1911.557, -42.12668, 390.5382, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("F_warrior_escudoasalto_light1", "MID");
				break;
			case 6:
				break;
			case 15:
				//SetFixAnim("astd");
				break;
			case 24:
				await track.Dialog.Msg("d_chapel_57_6_dlg_11");
				break;
			case 48:
				character.AddSessionObject(PropertyName.CHAPLE576_MQ_04_1, 1);
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
