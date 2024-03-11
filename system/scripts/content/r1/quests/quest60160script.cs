//--- Melia Script -----------------------------------------------------------
// Strong Beliefs
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Kazis.
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

[QuestScript(60160)]
public class Quest60160Script : QuestScript
{
	protected override void Load()
	{
		SetId(60160);
		SetName("Strong Beliefs");
		SetDescription("Talk to Believer Kazis");

		AddPrerequisite(new LevelPrerequisite(64));

		AddObjective("kill0", "Kill 12 Matsum(s) or Chafperor(s) or Ammon(s) or Infro Holder Shaman(s)", new KillObjective(12, 400381, 41268, 41266, 57598));

		AddReward(new ExpReward(8442, 8442));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("THORN21_BELIEVER03", "BeforeStart", BeforeStart);
		AddDialogHook("THORN21_BELIEVER03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN21_RP_1_1", "THORN21_RP_1", "I'll help you", "I am tired now"))
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

		await dialog.Msg("THORN21_RP_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

