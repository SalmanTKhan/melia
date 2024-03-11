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

[TrackScript("CORAL_44_2_SQ_50_TRACK")]
public class CORAL442SQ50TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CORAL_44_2_SQ_50_TRACK");
		//SetMap("f_coral_44_2");
		//CenterPos(-703.97,-66.60,-610.85);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-558.7165f, -66.05485f, -600.149f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 153118, "", "f_coral_44_2", -882.44, -66.6, -523.96, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155104, "", "f_coral_44_2", -883.47, -66.6, -524.82, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20026, "", "f_coral_44_2", -885.33, -66.6, -523.9, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58290, "", "f_coral_44_2", -443.5191, -44.7368, -634.0845, 74.42308);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20026, "", "f_coral_44_2", -725.059, -62.86551, -484.0215, 0.3448276);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20026, "", "f_coral_44_2", -644.3113, -66.60202, -667.9243, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20026, "", "f_coral_44_2", -806.4139, -66.60196, -730.7083, 0);
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
			case 1:
				CreateBattleBoxInLayer(character, track);
				break;
			case 29:
				//DRT_PLAY_MGAME("CORAL_44_2_SQ_50_MINI");
				//DRT_ACTOR_ATTACH_EFFECT("E_HUEVILLAGE_58_4_MQ11_potal_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_HUEVILLAGE_58_4_MQ11_potal_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_HUEVILLAGE_58_4_MQ11_potal_red", "BOT");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
