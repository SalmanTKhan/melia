//--- Melia Script -----------------------------------------------------------
// Rest of the Owl Sculptures
//--- Description -----------------------------------------------------------
// Quest to Burn the destroyed fragments of the Sculptures so that the Owls can rest in peace eternally.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(20077)]
public class Quest20077Script : QuestScript
{
	protected override void Load()
	{
		SetId(20077);
		SetName("Rest of the Owl Sculptures");
		SetDescription("Burn the destroyed fragments of the Sculptures so that the Owls can rest in peace eternally");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN13_ADDQUEST6_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(60312, 60312));
		AddReward(new ItemReward("expCard7", 1));
		AddReward(new ItemReward("Vis", 11088891));

		AddDialogHook("KATYN13_ADDQUEST6_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN13_ADDQUEST6_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		ZoneServer.Instance.World.FindNPC("KATYN13_ADDQUEST6_NPC")?.PlayEffectLocal(character.Connection, "F_burstup036_fire", 1f, "BOT");
		ZoneServer.Instance.World.FindNPC("KATYN13_ADDQUEST1_NPC")?.PlayEffectLocal(character.Connection, "F_burstup036_fire", 1f, "BOT");
		await Task.Delay(1000);
		dialog.HideNPC("KATYN13_ADDQUEST1_NPC");
		dialog.HideNPC("KATYN13_ADDQUEST6_NPC");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You've burnt the owl sculpture well!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

