//--- Melia Script -----------------------------------------------------------
// To prepare for the unknown
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Stella.
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

[QuestScript(70585)]
public class Quest70585Script : QuestScript
{
	protected override void Load()
	{
		SetId(70585);
		SetName("To prepare for the unknown");
		SetDescription("Talk to Monk Stella");

		AddPrerequisite(new LevelPrerequisite(271));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_5_SQ05"));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 11111));

		AddDialogHook("PILGRIM415_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM415_SQ_07", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM415_SQ_06_start", "PILGRIM41_5_SQ06", "Help despite having a nagging feeling", "Say that you have a bad feeling about this and decline"))
		{
			case 1:
				await dialog.Msg("PILGRIM415_SQ_06_agree");
				dialog.UnHideNPC("PILGRIM415_SQ_06");
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

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("PILGRIM41_5_SQ07");
	}
}

