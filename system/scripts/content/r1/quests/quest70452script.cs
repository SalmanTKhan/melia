//--- Melia Script -----------------------------------------------------------
// Thorough Procedure
//--- Description -----------------------------------------------------------
// Quest to Talk to Revelator Mihail.
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

[QuestScript(70452)]
public class Quest70452Script : QuestScript
{
	protected override void Load()
	{
		SetId(70452);
		SetName("Thorough Procedure");
		SetDescription("Talk to Revelator Mihail");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CASTLE65_3_MQ09"));

		AddObjective("collect0", "Collect 16 Magic Amplifier(s)", new CollectItemObjective("CASTLE65_3_SQ04_ITEM", 16));
		AddDrop("CASTLE65_3_SQ04_ITEM", 7.5f, "Sec_Zibu_Maize");

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1680));

		AddDialogHook("CASTLE653_MQ_04_2", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE653_MQ_04_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE653_SQ_04_start", "CASTLE65_3_SQ04", "I'll bring it to you as soon as I have it", "It doesn't seem like we need to take action"))
		{
			case 1:
				await dialog.Msg("CASTLE653_SQ_04_agree");
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

