//--- Melia Script -----------------------------------------------------------
// Offerings to the Goddess (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Samsonas.
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

[QuestScript(90006)]
public class Quest90006Script : QuestScript
{
	protected override void Load()
	{
		SetId(90006);
		SetName("Offerings to the Goddess (1)");
		SetDescription("Talk to Samsonas");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 8 Rajatadpole Meat(s)", new CollectItemObjective("F_3CMLAKE_83_SQ_ITEM1", 8));
		AddDrop("F_3CMLAKE_83_SQ_ITEM1", 10f, "Rajatadpole");

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1235));

		AddDialogHook("3CMLAKE_83_PEOPLE1", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_83_PEOPLE1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE_83_SQ_01_DLG_01", "F_3CMLAKE_83_SQ_01", "That's a bit weird but I'll help you", "There's no way the goddesses would do that"))
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


		return HookResult.Break;
	}
}

