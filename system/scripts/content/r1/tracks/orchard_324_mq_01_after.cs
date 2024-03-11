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

[TrackScript("ORCHARD_324_MQ_01_AFTER")]
public class ORCHARD324MQ01AFTER : TrackScript
{
	protected override void Load()
	{
		SetId("ORCHARD_324_MQ_01_AFTER");
		//SetMap("f_orchard_32_4");
		//CenterPos(-79.44,-2.15,695.08);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-79.44206f, -2.146326f, 695.0839f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156043, "", "f_orchard_32_4", -46.79352, 0.8066463, 870.8289, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155024, "", "f_orchard_32_4", -46.97593, 0.8066463, 813.6766, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155024, "", "f_orchard_32_4", -91.37969, 0.8066463, 897.446, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155024, "", "f_orchard_32_4", 1.99358, 0.8066463, 897.5681, 6.95122);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58087, "", "f_orchard_32_4", -61.85375, -2.14647, 576.5828, 0.5);
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
			case 28:
				await track.Dialog.Msg("ORCHARD_324_MQ_01_track_03");
				break;
			case 29:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle25_red", "BOT");
				break;
			case 33:
				character.AddonMessage("NOTICE_Dm_!", "The Demon Lord Zaura ran away!", 3);
				character.AddSessionObject(PropertyName.ORCHARD_324_MQ_01, 1);
				break;
			case 34:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
