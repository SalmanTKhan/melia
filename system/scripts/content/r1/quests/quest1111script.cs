//--- Melia Script -----------------------------------------------------------
// The Origin of Physique [Swordsman Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Swordsman Master.
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

[QuestScript(1111)]
public class Quest1111Script : QuestScript
{
	protected override void Load()
	{
		SetId(1111);
		SetName("The Origin of Physique [Swordsman Advancement]");
		SetDescription("Talk to the Swordsman Master");

		AddPrerequisite(new LevelPrerequisite(45));

		AddObjective("kill0", "Kill 2 Glizardon(s)", new KillObjective(2, MonsterId.Glizardon));

		AddDialogHook("MASTER_SWORDMAN", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_SWORDMAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_WARRIOR2_1_select1", "JOB_WARRIOR2_1", "How do you receive enlightenment?", "I will come back later"))
		{
			case 1:
				await dialog.Msg("JOB_WARRIOR2_1_AG");
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

		await dialog.Msg("JOB_WARRIOR2_1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

