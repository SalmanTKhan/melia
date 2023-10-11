//--- Melia Script -----------------------------------------------------------
// Anything For Our Master
//--- Description -----------------------------------------------------------
// Quest to Talk to Steward Valen.
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

[QuestScript(70046)]
public class Quest70046Script : QuestScript
{
	protected override void Load()
	{
		SetId(70046);
		SetName("Anything For Our Master");
		SetDescription("Talk to Steward Valen");

		AddPrerequisite(new LevelPrerequisite(155));

		AddObjective("kill0", "Kill 12 Green Carcashu(s)", new KillObjective(12, MonsterId.Carcashu_Green));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 4495));

		AddDialogHook("FARM493_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FARM493_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_3_SQ_01_1", "FARM49_3_SQ01", "I agree", "Tell him that it's not right"))
		{
			case 1:
				await dialog.Msg("FARM49_3_SQ_01_2");
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

		await dialog.Msg("FARM49_3_SQ_01_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

