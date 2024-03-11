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

[TrackScript("ABBEY22_5_SQ11_TRACK")]
public class ABBEY225SQ11TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ABBEY22_5_SQ11_TRACK");
		//SetMap("d_abbey_22_5");
		//CenterPos(-1319.46,116.32,-108.27);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1319.458f, 116.324f, -108.2683f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 57840, "", "d_abbey_22_5", -1989.558, 184.3334, -24.0924, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 58863, "", "d_abbey_22_5", -1828.311, 170.5324, -93.82265, 7.777778);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58863, "", "d_abbey_22_5", -1777.782, 168.3171, -45.86087, 615);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58863, "", "d_abbey_22_5", -1832.59, 170.5504, -155.2495, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58863, "", "d_abbey_22_5", -1744.311, 167.9555, -106.2531, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58863, "", "d_abbey_22_5", -1762.275, 170.5612, -170.5045, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 58863, "", "d_abbey_22_5", -1751.409, 167.6903, -14.80592, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 58862, "", "d_abbey_22_5", -1991.404, 170.4782, -85.44925, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 58862, "", "d_abbey_22_5", -1928.4, 170.4469, -3.194238, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 58857, "", "d_abbey_22_5", -1998.051, 170.4448, -109.4255, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 58857, "", "d_abbey_22_5", -1894.984, 170.453, -11.55699, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_ATTACH_EFFECT("I_emo_confuse", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("I_emo_confuse", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("I_emo_confuse", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("I_emo_confuse", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("I_emo_confuse", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("I_emo_confuse", "TOP");
				break;
			case 6:
				await track.Dialog.Msg("ABBEY22_5_SUBQ11_DLG1");
				break;
			case 17:
				await track.Dialog.Msg("ABBEY22_5_SUBQ11_DLG2");
				break;
			case 18:
				character.AddonMessage("NOTICE_Dm_Clear", "Tell Agailla Flurry that{nl}Ambition Hauberk will head towards Deception Hauberk", 3);
				break;
			case 19:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
