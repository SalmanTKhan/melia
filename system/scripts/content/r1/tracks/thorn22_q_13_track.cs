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

[TrackScript("THORN22_Q_13_TRACK")]
public class THORN22Q13TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("THORN22_Q_13_TRACK");
		//SetMap("d_thorn_22");
		//CenterPos(-932.41,554.74,-1263.16);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 41290, "", "d_thorn_22", -1036.984, 554.2394, -751.2939, 22.85714);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 41290, "", "d_thorn_22", -1063.228, 554.2394, -797.3353, 40);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 41290, "", "d_thorn_22", -1030.989, 554.2394, -780.6254, 36.5);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 41290, "", "d_thorn_22", -1061.611, 554.2394, -766.212, 26.31579);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 41290, "", "d_thorn_22", -1062.426, 554.2394, -751.0443, 26.57895);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 41290, "", "d_thorn_22", -1018.995, 554.2394, -757.2493, 27.10526);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 41290, "", "d_thorn_22", -1032.586, 554.2394, -726.7523, 23.68421);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 41290, "", "d_thorn_22", -1068.372, 554.2394, -734.105, 10.52632);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20125, "", "d_thorn_22", -996.5, 554.74, -1339.73, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		character.Movement.MoveTo(new Position(-976.5644f, 554.7529f, -1335.389f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 22:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke039", "BOT");
				break;
			case 24:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke039", "BOT");
				break;
			case 25:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke039", "BOT");
				break;
			case 28:
				//DRT_ACTOR_PLAY_EFT("I_smoke039", "BOT", 0);
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("I_smoke039", "BOT", 0);
				break;
			case 30:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke039", "BOT");
				break;
			case 32:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke039", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke039", "BOT");
				break;
			case 33:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke039", "BOT");
				break;
			case 34:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke039", "BOT");
				break;
			case 35:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke039", "BOT");
				break;
			case 38:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke039", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke039", "BOT");
				break;
			case 40:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
