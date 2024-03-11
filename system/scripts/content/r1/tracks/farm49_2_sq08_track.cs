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

[TrackScript("FARM49_2_SQ08_TRACK")]
public class FARM492SQ08TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FARM49_2_SQ08_TRACK");
		//SetMap("f_farm_49_2");
		//CenterPos(-1467.13,77.63,567.88);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1469.265f, 77.62789f, 564.209f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 20153, "Edward", "f_farm_49_2", -1969.174, 77.6279, 526.7649, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 401462, "", "f_farm_49_2", -1871.67, 77.6279, 766.55, 39.16666);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 401462, "", "f_farm_49_2", -1803.078, 77.6279, 696.3296, 49.16666);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 401462, "", "f_farm_49_2", -1944.913, 77.6279, 775.0758, 39.58333);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 35:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 39:
				//TRACK_SETTENDENCY();
				character.AddonMessage("NOTICE_Dm_!", "Protect Edward from monsters!", 5);
				//DRT_PLAY_MGAME("FARM49_2_SQ08_TRACK_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
