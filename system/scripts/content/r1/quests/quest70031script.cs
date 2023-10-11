//--- Melia Script -----------------------------------------------------------
// Today's Work
//--- Description -----------------------------------------------------------
// Quest to Talk to Tenant Weiss.
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

[QuestScript(70031)]
public class Quest70031Script : QuestScript
{
	protected override void Load()
	{
		SetId(70031);
		SetName("Today's Work");
		SetDescription("Talk to Tenant Weiss");

		AddPrerequisite(new LevelPrerequisite(152));

		AddObjective("kill0", "Kill 12 Cyst(s)", new KillObjective(12, MonsterId.Cyst));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 4408));

		AddDialogHook("FARM492_SQ_05", "BeforeStart", BeforeStart);
		AddDialogHook("FARM492_SQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_2_SQ_05_1", "FARM49_2_SQ05", "Leave it to me", "About the managers at the farm of Shaton family", "Tell him that it's hard"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FARM49_2_SQ_05_2");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FARM49_2_SQ_05_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

