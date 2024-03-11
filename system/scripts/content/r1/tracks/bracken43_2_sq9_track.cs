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

[TrackScript("BRACKEN43_2_SQ9_TRACK")]
public class BRACKEN432SQ9TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("BRACKEN43_2_SQ9_TRACK");
		//SetMap("f_bracken_43_2");
		//CenterPos(-236.95,62.69,-911.58);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153163, "Oscaras", "f_bracken_43_2", -218.69, 62.68, -895.09, 0, "Our_Forces");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-233.0189f, 62.68744f, -909.6061f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 58449, "", "f_bracken_43_2", -298.8041, 62.68742, -957.739, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58441, "", "f_bracken_43_2", -336.1756, 62.68744, -840.6184, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58441, "", "f_bracken_43_2", -344.9238, 62.68742, -903.3955, 0);
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
			case 7:
				character.AddonMessage("NOTICE_Dm_scroll", "The monsters are attacking.{nl}Pass the cure safely to Oscaras.", 3);
				break;
			case 9:
				CreateBattleBoxInLayer(character, track);
				//DRT_PLAY_MGAME("BRACKEN432_SUBQ9_MINI");
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
