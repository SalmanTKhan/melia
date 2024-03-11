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

[TrackScript("ZACHA2F_MQ_02_TRACK")]
public class ZACHA2FMQ02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ZACHA2F_MQ_02_TRACK");
		//SetMap("d_zachariel_33");
		//CenterPos(-164.40,648.12,-1322.76);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-146.0553f, 648.1295f, -1431.697f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 47260, "", "d_zachariel_33", -188, 645, -1420, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47253, "", "d_zachariel_33", -210, 649, -882, 0, "Our_Forces");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47253, "", "d_zachariel_33", 3, 649, -722, 0, "Our_Forces");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 47253, "", "d_zachariel_33", -208, 649, -566, 0, "Our_Forces");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 47253, "", "d_zachariel_33", -379, 649, -723, 0, "Our_Forces");
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				//DRT_PLAY_MGAME("ZACHA2F_MQ_02_MINI");
				break;
			case 7:
				character.AddonMessage("NOTICE_Dm_!", "Protect the Royal Mausoleum's Stone Lanterns from the guardians!", 3);
				break;
			case 19:
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
