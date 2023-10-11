//--- Melia Script -----------------------------------------------------------
// Large-Scale Search Operation (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Chaser Talbasi.
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

[QuestScript(60099)]
public class Quest60099Script : QuestScript
{
	protected override void Load()
	{
		SetId(60099);
		SetName("Large-Scale Search Operation (1)");
		SetDescription("Talk with Chaser Talbasi");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("SIAU15RE_MQ_06"));

		AddObjective("collect0", "Collect 4 Priest Gelija's Memo(s)", new CollectItemObjective("SIAU11RE_MQ_01_ITEM", 4));
		AddDrop("SIAU11RE_MQ_01_ITEM", 7f, 58009, 58007, 58088, 41294);

		AddReward(new ExpReward(13430, 13430));
		AddReward(new ItemReward("expCard2", 1));
		AddReward(new ItemReward("Vis", 169));

		AddDialogHook("SIAULIAI11RE_TALBASI", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI11RE_TALBASI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU11RE_MQ_01_01", "SIAU11RE_MQ_01", "I'll try to find them", "It's going to be hard to find it"))
		{
			case 1:
				await dialog.Msg("SIAU11RE_MQ_01_01_AG");
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


		return HookResult.Break;
	}
}

