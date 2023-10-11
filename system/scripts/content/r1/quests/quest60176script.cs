//--- Melia Script -----------------------------------------------------------
// Lost Pilgrim
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Seronia.
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

[QuestScript(60176)]
public class Quest60176Script : QuestScript
{
	protected override void Load()
	{
		SetId(60176);
		SetName("Lost Pilgrim");
		SetDescription("Talk to Pilgrim Seronia");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 11 Ellomago(s) or Old Hook(s) or Hallowventer(s)", new KillObjective(11, 58144, 58145, 58143));

		AddReward(new ExpReward(24571, 24571));
		AddReward(new ItemReward("expCard5", 1));
		AddReward(new ItemReward("Vis", 1640));

		AddDialogHook("PILGRIM311_RP_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM311_RP_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM311_RP_1_1", "PILGRIM311_RP_1", "Stay here and rest for a while.", "I'm sorry"))
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

