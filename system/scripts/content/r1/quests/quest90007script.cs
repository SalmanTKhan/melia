//--- Melia Script -----------------------------------------------------------
// Offerings to the Goddess (2)
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

[QuestScript(90007)]
public class Quest90007Script : QuestScript
{
	protected override void Load()
	{
		SetId(90007);
		SetName("Offerings to the Goddess (2)");
		SetDescription("Talk to Samsonas");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_83_SQ_01"));

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

		switch (await dialog.Select("3CMLAKE_83_SQ_02_DLG_01", "F_3CMLAKE_83_SQ_02", "That sounds suspicious, but I'll go", "I don't think this is it"))
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

