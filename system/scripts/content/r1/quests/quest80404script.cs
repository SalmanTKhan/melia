//--- Melia Script -----------------------------------------------------------
// Investigate the Magic Research Facility
//--- Description -----------------------------------------------------------
// Quest to Talk to Owynia Dilben.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(80404)]
public class Quest80404Script : QuestScript
{
	protected override void Load()
	{
		SetId(80404);
		SetName("Investigate the Magic Research Facility");
		SetDescription("Talk to Owynia Dilben");

		AddPrerequisite(new LevelPrerequisite(380));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_1_SQ_04"));

		AddObjective("kill0", "Kill 1 Wastrel", new KillObjective(1, MonsterId.Boss_Wastrel_Mission_Quest));

		AddDialogHook("NICO811_NPC1_2", "BeforeStart", BeforeStart);
		AddDialogHook("NICO811_NPC1_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_NICOPOLIS_UNIQUE_MQ1_ST", "F_NICOPOLIS_UNIQUE_MQ1", "Leave it to me.", "I'm not ready yet."))
		{
			case 1:
				await dialog.Msg("F_NICOPOLIS_UNIQUE_MQ1_AFST");
				dialog.UnHideNPC("INSTANCE_DUNGEON_NICO811");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("F_NICOPOLIS_UNIQUE_MQ1_SU");
		dialog.HideNPC("INSTANCE_DUNGEON_NICO811");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

