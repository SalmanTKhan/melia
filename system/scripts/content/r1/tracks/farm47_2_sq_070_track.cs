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

[TrackScript("FARM47_2_SQ_070_TRACK")]
public class FARM472SQ070TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FARM47_2_SQ_070_TRACK");
		//SetMap("None");
		//CenterPos(-525.16,0.71,956.10);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var npc0 = Shortcuts.AddNpc(0, 153047, "UnvisibleName", "None", -668.16, 0.71, 1062.21, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		character.Movement.MoveTo(new Position(-602.3983f, 0.7131f, 1067.231f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 47223, "UnvisibleName", "None", -627.14, 0.71, 1065.65, 0);
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
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_fire001_1", "BOT");
				break;
			case 7:
				character.AddonMessage("NOTICE_Dm_!", "The magic circle is on fire!{nl}Get kindling from Orange Dandel and keep the fire alive!", 6);
				//DRT_PLAY_MGAME("FARM47_2_SQ_070_MINI");
				break;
			case 9:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
