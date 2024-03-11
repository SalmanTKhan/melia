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

[TrackScript("F_NICOPOLIS_81_3_SQ_01_TRACK")]
public class FNICOPOLIS813SQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_NICOPOLIS_81_3_SQ_01_TRACK");
		//SetMap("f_nicopolis_81_3");
		//CenterPos(1401.78,-28.63,238.18);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1401.778f, -28.63441f, 238.1767f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 153214, "", "f_nicopolis_81_3", 1434.557, -28.64099, 226.3431, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 151000, "", "f_nicopolis_81_3", 1445.66, -28.66, 192.64, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59151, "", "f_nicopolis_81_3", 1172.988, -53.2327, -143.7458, 75.78947);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59151, "", "f_nicopolis_81_3", 1237.928, -53.17559, -168.9916, 73.75);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59151, "", "f_nicopolis_81_3", 1308.541, -51.688, -192.1587, 71.84211);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59161, "", "f_nicopolis_81_3", 1265.083, -38.20805, -260.4355, 78.25);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59161, "", "f_nicopolis_81_3", 1302.361, -47.46824, -281.7154, 78.42105);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59151, "", "f_nicopolis_81_3", 1747.015, -28.63495, 156.7272, 69.23077);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59151, "", "f_nicopolis_81_3", 1813.583, -15.20063, 150.3893, 63.57143);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 59151, "", "f_nicopolis_81_3", 1877.977, -15.20063, 208.5203, 89.23077);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 59161, "", "f_nicopolis_81_3", 1903.871, -15.20063, 124.9401, 89.70588);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				break;
			case 4:
				//DRT_ACTOR_PLAY_EFT("F_spread_out006_shieldpush", "BOT", 0);
				break;
			case 29:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
