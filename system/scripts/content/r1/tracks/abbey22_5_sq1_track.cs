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

[TrackScript("ABBEY22_5_SQ1_TRACK")]
public class ABBEY225SQ1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ABBEY22_5_SQ1_TRACK");
		//SetMap("d_abbey_22_5");
		//CenterPos(1456.99,-59.07,808.87);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1456.991f, -59.06966f, 808.8671f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 57840, "", "d_abbey_22_5", 1904.62, -33.07, 758.18, 780);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155045, "", "d_abbey_22_5", 1876.007, -33.07492, 851.3535, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 153188, "", "d_abbey_22_5", 1950.13, -33.07, 863.86, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 25:
				await track.Dialog.Msg("ABBEY22_5_SUBQ1_DLG1");
				break;
			case 26:
				character.AddonMessage("NOTICE_Dm_scroll", "Tell Deception Hauberk what you have learned from Agailla Flurry", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
