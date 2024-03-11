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

[TrackScript("PARTY_Q_011_TRACK")]
public class PARTYQ011TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PARTY_Q_011_TRACK");
		//SetMap("None");
		//CenterPos(0.00,0.00,0.00);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 152022, "", "None", -1589, 72, 60.00001, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 8:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 9:
				//DRT_PLAY_MGAME("PARTY_Q_011_MINI");
				break;
			case 11:
				character.AddonMessage("NOTICE_Dm_!", "The Vubbes who felt intimidated are coming!{nl}Please protect the incense burners!", 4);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
