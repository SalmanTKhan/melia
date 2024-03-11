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

[TrackScript("REMAIN39_SQ03_TRACK")]
public class REMAIN39SQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("REMAIN39_SQ03_TRACK");
		//SetMap("f_remains_39");
		//CenterPos(-1379.17,194.77,-192.81);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47160, "", "f_remains_39", -1385, 195, -194, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-1374.906f, 194.769f, -217.8604f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 57274, "", "f_remains_39", -1206.14, 194.769, -330.8704, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 10033, "", "f_remains_39", -1450.275, 194.769, -182.2167, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 10033, "", "f_remains_39", -1420.539, 194.769, -133.1705, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 10033, "", "f_remains_39", -1364.237, 194.769, -134.7134, 20);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var npc0 = Shortcuts.AddNpc(0, 10033, "", "f_remains_39", -1452.118, 194.769, -227.276, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				break;
			case 10:
				//DRT_SETHOOKMSGOWNER(0, 0);
				break;
			case 11:
				//DRT_SETHOOKMSGOWNER(0, 0);
				//DRT_SETHOOKMSGOWNER(0, 0);
				break;
			case 12:
				//DRT_SETHOOKMSGOWNER(0, 0);
				break;
			case 30:
				character.AddonMessage("NOTICE_Dm_!", "Defeat Unicorn together with Soldier's Spirit!", 3);
				break;
			case 33:
				//TRACK_SETTENDENCY();
				break;
			case 44:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_MON_LOOKAT();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
