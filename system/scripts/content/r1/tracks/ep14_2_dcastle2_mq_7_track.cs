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

[TrackScript("EP14_2_DCASTLE2_MQ_7_TRACK")]
public class EP142DCASTLE2MQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_2_DCASTLE2_MQ_7_TRACK");
		//SetMap("ep14_2_d_castle_2");
		//CenterPos(-1349.71,68.03,654.07);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 150032, "RP", "ep14_2_d_castle_2", -1373.152, 68.03178, 653.8824, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-1346.848f, 68.03178f, 654.5366f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 59745, "", "ep14_2_d_castle_2", -1448.317, 68.03178, 598.9141, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59750, "", "ep14_2_d_castle_2", -1303.422, 68.03178, 721.6141, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59750, "", "ep14_2_d_castle_2", -1442.006, 68.03178, 734.8436, 0);
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
			case 12:
				character.AddonMessage("NOTICE_Dm_!", "Magic Control Device can not be activated due to lack of mana!", 2);
				break;
			case 19:
				break;
			case 32:
				CreateBattleBoxInLayer(character, track);
				break;
			case 34:
				//DRT_PLAY_MGAME("EP14_2_DCASTLE2_MQ_7_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
