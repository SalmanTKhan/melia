//--- Melia Script -----------------------------------------------------------
// Truth of the Suspicious Seal Stone (1)
//--- Description -----------------------------------------------------------
// Quest to Find the Sealed Stone.
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

[QuestScript(17025)]
public class Quest17025Script : QuestScript
{
	protected override void Load()
	{
		SetId(17025);
		SetName("Truth of the Suspicious Seal Stone (1)");
		SetDescription("Find the Sealed Stone");

		AddPrerequisite(new LevelPrerequisite(126));
		AddPrerequisite(new CompletedPrerequisite("FTOWER43_SQ_02"), new CompletedPrerequisite("FTOWER43_SQ_04"), new CompletedPrerequisite("FTOWER44_SQ_04"), new CompletedPrerequisite("FTOWER44_SQ_05"));

		AddObjective("kill0", "Kill 15 Dimmer(s) or Black Shaman Doll(s) or Black Drake(s)", new KillObjective(15, 47395, 47399, 401623));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3150));

		AddDialogHook("FTOWER45_SQ_04", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER45_SQ_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER45_SQ_04_ST", "FTOWER45_SQ_04", "Defeat the observing monsters", "About the possessed soul", "I'm busy now"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FTOWER45_SQ_04_STP");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FTOWER45_SQ_04_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER45_SQ_05");
	}
}

