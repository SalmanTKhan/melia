//--- Melia Script -----------------------------------------------------------
// Nice Place to Live
//--- Description -----------------------------------------------------------
// Quest to Talk to Laterous.
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

[QuestScript(60171)]
public class Quest60171Script : QuestScript
{
	protected override void Load()
	{
		SetId(60171);
		SetName("Nice Place to Live");
		SetDescription("Talk to Laterous");

		AddPrerequisite(new LevelPrerequisite(84));

		AddObjective("kill0", "Kill 15 Orange Hamming(s) or Orange Popolion(s) or Spion Mage(s)", new KillObjective(15, 57348, 400984, 57608));

		AddReward(new ExpReward(49142, 49142));
		AddReward(new ItemReward("expCard5", 2));
		AddReward(new ItemReward("Vis", 1680));

		AddDialogHook("SIAU474_RP_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAU474_RP_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU474_RP_1_1", "SIAU474_RP_1", "Alright, I'll help you", "That doesn't sound right."))
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

		await dialog.Msg("SIAU474_RP_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

