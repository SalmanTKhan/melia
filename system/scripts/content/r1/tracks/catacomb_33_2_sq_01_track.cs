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

[TrackScript("CATACOMB_33_2_SQ_01_TRACK")]
public class CATACOMB332SQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CATACOMB_33_2_SQ_01_TRACK");
		//SetMap("id_catacomb_33_2");
		//CenterPos(-916.15,138.98,448.31);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-875.9247f, 138.9071f, 439.7552f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156000, "", "id_catacomb_33_2", -554.8237, 138.1478, 449.3895, 1.25);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 58114, "", "id_catacomb_33_2", -575.603, 138.6237, 590.1687, 78.57143);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58114, "", "id_catacomb_33_2", -538.7764, 138.4867, 564.1402, 67);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58114, "", "id_catacomb_33_2", -492.4804, 138.4681, 574.6218, 78.125);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58108, "", "id_catacomb_33_2", -516.9257, 140.9773, 283.4763, 44.16666);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58108, "", "id_catacomb_33_2", -745.6752, 138.6844, 470.8875, 31.11111);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 58108, "", "id_catacomb_33_2", -662.1143, 159.6908, 378.0045, 42.5);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 7:
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke008", "BOT");
				break;
			case 21:
				break;
			case 23:
				break;
			case 25:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground12_red", "BOT");
				break;
			case 34:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
