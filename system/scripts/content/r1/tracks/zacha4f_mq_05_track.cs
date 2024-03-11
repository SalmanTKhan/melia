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

[TrackScript("ZACHA4F_MQ_05_TRACK")]
public class ZACHA4FMQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ZACHA4F_MQ_05_TRACK");
		//SetMap("d_zachariel_35");
		//CenterPos(-459.65,-27.55,1133.79);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-307.8384f, -27.5412f, 1249.847f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 57081, "", "d_zachariel_35", -572.5139, -27.5512, 1126.131, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47260, "", "d_zachariel_35", -498.3269, -27.5512, 1131.22, 0);
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
			case 15:
				character.AddonMessage("NOTICE_Dm_!", "Stop Bearkaras from destroying the Royal Mausoleum", 3);
				break;
			case 18:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
