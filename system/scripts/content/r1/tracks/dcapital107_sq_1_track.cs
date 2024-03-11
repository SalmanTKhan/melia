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

[TrackScript("DCAPITAL107_SQ_1_TRACK")]
public class DCAPITAL107SQ1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("DCAPITAL107_SQ_1_TRACK");
		//SetMap("f_dcapital_107");
		//CenterPos(381.68,39.79,-1339.65);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(388.1386f, 39.79394f, -1372.084f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154011, "", "f_dcapital_107", 334.8145, 39.79394, -1333.399, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154016, "", "f_dcapital_107", 278.1448, 39.79393, -961.6696, 82.75);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 103052, "", "f_dcapital_107", 377.9316, 39.79394, -953.6495, 64.4);
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
			case 10:
				break;
			case 11:
				break;
			case 29:
				character.AddSessionObject(PropertyName.DCAPITAL107_SQ_1, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
