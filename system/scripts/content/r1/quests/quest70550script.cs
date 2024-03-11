//--- Melia Script -----------------------------------------------------------
// Luring the culprit
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Vados.
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

[QuestScript(70550)]
public class Quest70550Script : QuestScript
{
	protected override void Load()
	{
		SetId(70550);
		SetName("Luring the culprit");
		SetDescription("Talk to Pilgrim Vados");

		AddPrerequisite(new LevelPrerequisite(265));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_4_SQ10"));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10865));

		AddDialogHook("PILGRIM414_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM414_SQ_12", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM414_SQ_11_start1", "PILGRIM41_4_SQ11", "Leave it to me", "Say that you are not up to the task"))
		{
			case 1:
				await dialog.Msg("PILGRIM414_SQ_11_agree");
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
		character.Quests.Start("PILGRIM41_4_SQ12");
	}
}

