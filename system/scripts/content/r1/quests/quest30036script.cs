//--- Melia Script -----------------------------------------------------------
// Eternal Amjinas [Sorcerer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sorcerer Master.
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

[QuestScript(30036)]
public class Quest30036Script : QuestScript
{
	protected override void Load()
	{
		SetId(30036);
		SetName("Eternal Amjinas [Sorcerer Advancement]");
		SetDescription("Talk to the Sorcerer Master");

		AddPrerequisite(new LevelPrerequisite(235));

		AddDialogHook("JOB_SORCERER4_1", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SORCERER4_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_SORCERER_6_1_select", "JOB_SORCERER_6_1", "I will ask him", "Tell him that it will be better to listen directly"))
		{
			case 1:
				await dialog.Msg("JOB_SORCERER_6_1_agree");
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

		await dialog.Msg("JOB_SORCERER_6_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

