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

[TrackScript("PARTY_Q_090_TRACK")]
public class PARTYQ090TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PARTY_Q_090_TRACK");
		//SetMap("f_farm_47_2");
		//CenterPos(184.63,-92.48,-1881.75);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47121, "", "f_farm_47_2", 190.877, -92.4781, -1888.226, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20026, "", "f_farm_47_2", 189.4991, -92.4781, -1884.065, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("E_HUEVILLAGE_58_4_MQ11_potal", "MID");
				break;
			case 16:
				character.AddonMessage("NOTICE_Dm_!", "The portal suddenly opened!", 3);
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_rize002_violet2", "BOT");
				break;
			case 28:
				//DRT_PLAY_MGAME("PARTY_Q_090_MINI");
				break;
			case 29:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
