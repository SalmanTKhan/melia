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

[TrackScript("BRACKEN43_3_SQ10_1_TRACK")]
public class BRACKEN433SQ101TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("BRACKEN43_3_SQ10_1_TRACK");
		//SetMap("f_bracken_43_3");
		//CenterPos(2247.17,190.10,1701.21);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(2247.173f, 190.102f, 1701.208f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 47160, "UnvisibleName", "f_bracken_43_3", 2255.21, 188.56, 1713.72, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 58445, "", "f_bracken_43_3", 2067.244, 216.5491, 1490.66, 106.25);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58445, "", "f_bracken_43_3", 2107.901, 211.3708, 1451.91, 102.5);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58445, "", "f_bracken_43_3", 2016.561, 221.9183, 1460.038, 126.25);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58445, "", "f_bracken_43_3", 2044.639, 213.8133, 1407.986, 145);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58445, "", "f_bracken_43_3", 1992.128, 225.4955, 1421.097, 69.0909);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 58445, "", "f_bracken_43_3", 2019.237, 218.7361, 1382.973, 76.81818);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 27:
				character.AddonMessage("NOTICE_Dm_scroll", "There are demons after the Flechette!{nl}Defeat the demons and retrieve the Flechette.", 3);
				break;
			case 29:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
