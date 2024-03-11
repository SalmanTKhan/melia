//--- Melia Script -----------------------------------------------------------
// A Sword and Shield for the People (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Knight Commander Uska.
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

[QuestScript(72143)]
public class Quest72143Script : QuestScript
{
	protected override void Load()
	{
		SetId(72143);
		SetName("A Sword and Shield for the People (4)");
		SetDescription("Talk to Knight Commander Uska");

		AddPrerequisite(new LevelPrerequisite(135));
		AddPrerequisite(new CompletedPrerequisite("MASTER_HIGHLANDER2_3"));

		AddReward(new ItemReward("Point_Stone_100_Q", 1));

		AddDialogHook("KLAPEDA_USKA", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_HIGHLANDER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_HIGHLANDER4_4_01", "MASTER_HIGHLANDER2_4", "I'll return to the Highlander Master", "I'll be back after a while"))
		{
			case 1:
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

		await dialog.Msg("MASTER_HIGHLANDER2_4_DLG2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

