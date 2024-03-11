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

[TrackScript("VPRISON511_MQ_05_TRACK")]
public class VPRISON511MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("VPRISON511_MQ_05_TRACK");
		//SetMap("d_velniasprison_51_1");
		//CenterPos(-1741.74,346.41,-489.68);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 154001, "UnvisibleName", "d_velniasprison_51_1", -1913.114, 358.0498, -470.4406, 12.5);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57582, "", "d_velniasprison_51_1", -1809.314, 346.412, -484.9925, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47514, "", "d_velniasprison_51_1", -1968.887, 380.5843, -450.4697, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57827, "", "d_velniasprison_51_1", -1735.534, 346.4104, -414.205, 0);
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
			case 8:
				//DRT_ACTOR_PLAY_EFT("F_hit_rize", "MID", 0);
				break;
			case 15:
				Send.ZC_NORMAL.Notice(character, "You can't trap me!", 1.5f);
				break;
			case 21:
				//DRT_ACTOR_PLAY_EFT("I_smoke001_dark", "MID", 0);
				//DRT_SETHOOKMSGOWNER(0, 1);
				break;
			case 28:
				//DRT_ADDBUFF("HPLock", 10, 0, 0, 1);
				//DRT_ADDBUFF("HPLock", 10, 0, 0, 1);
				break;
			case 29:
				character.AddonMessage("NOTICE_Dm_!", "Defeat Demon Lord Blut!", 3);
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				//InsertHate(999);
				//InsertHate(999);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
