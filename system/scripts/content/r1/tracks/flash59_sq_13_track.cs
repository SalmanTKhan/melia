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

[TrackScript("FLASH59_SQ_13_TRACK")]
public class FLASH59SQ13TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FLASH59_SQ_13_TRACK");
		//SetMap("f_flash_59");
		//CenterPos(-229.65,109.42,734.42);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-233.3082f, 109.3169f, 728.5974f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 147416, "", "f_flash_59", -200.24, 109.32, 725.95, 20);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57292, "", "f_flash_59", 178.4312, 134.7757, 776.5472, 90.45454);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47462, "", "f_flash_59", 157.5717, 134.7757, 679.9279, 88.14815);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 47462, "", "f_flash_59", 142.8493, 134.7757, 653.4838, 95.37037);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 47462, "", "f_flash_59", 136.1613, 134.7757, 699.4104, 92.03703);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 10033, "Security Guard", "f_flash_59", -380.9825, 109.4169, 686.2678, 0, "Our_Forces");
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 10033, "Security Guard", "f_flash_59", -387.3885, 109.4169, 762.5255, 0, "Our_Forces");
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 10033, "Security Guard", "f_flash_59", -323.1813, 109.4169, 818.9205, 0, "Our_Forces");
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 10033, "Security Guard", "f_flash_59", -112.5459, 109.4169, 810.18, 0, "Our_Forces");
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 10033, "Security Guard", "f_flash_59", -351.9361, 109.4169, 645.172, 0, "Our_Forces");
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 10033, "Security Guard", "f_flash_59", -358.9632, 109.4169, 603.1271, 0, "Our_Forces");
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 10033, "Security Guard", "f_flash_59", -320.5778, 109.4169, 608.4824, 0, "Our_Forces");
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 10033, "Security Guard", "f_flash_59", -279.3743, 109.4169, 821.7751, 0, "Our_Forces");
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 10033, "Security Guard", "f_flash_59", -193.9993, 109.4169, 864.5016, 0, "Our_Forces");
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 10033, "Security Guard", "f_flash_59", -175.0068, 109.4169, 885.7013, 0, "Our_Forces");
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 20152, "", "f_flash_59", -364.5241, 109.3169, 750.5113, 130);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 11282, "", "f_flash_59", -373.0545, 109.3169, 752.9014, 133.2143);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 147403, "", "f_flash_59", -354.1182, 109.3169, 759.0174, 122.1429);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke014_2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke038_blue", "BOT");
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke014_2", "BOT");
				break;
			case 18:
				//DRT_SETHOOKMSGOWNER(0, 1);
				//DRT_SETHOOKMSGOWNER(0, 1);
				//DRT_SETHOOKMSGOWNER(0, 1);
				//DRT_SETHOOKMSGOWNER(0, 1);
				//DRT_SETHOOKMSGOWNER(0, 1);
				break;
			case 19:
				//DRT_SETHOOKMSGOWNER(0, 1);
				//DRT_SETHOOKMSGOWNER(0, 1);
				//DRT_SETHOOKMSGOWNER(0, 1);
				break;
			case 21:
				//DRT_SETHOOKMSGOWNER(0, 1);
				//DRT_SETHOOKMSGOWNER(0, 1);
				break;
			case 23:
				//DRT_SETHOOKMSGOWNER(0, 1);
				break;
			case 41:
				break;
			case 42:
				break;
			case 43:
				break;
			case 46:
				//InsertHate(999);
				//InsertHate(999);
				//InsertHate(999);
				break;
			case 47:
				//InsertHate(999);
				//InsertHate(999);
				//InsertHate(999);
				//InsertHate(999);
				break;
			case 48:
				//InsertHate(999);
				break;
			case 49:
				//InsertHate(999);
				break;
			case 50:
				//InsertHate(999);
				break;
			case 64:
				character.AddonMessage("NOTICE_Dm_!", "Defeat Saltistter!", 3);
				break;
			case 68:
				//InsertHate(999);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
