//--- Melia Script -----------------------------------------------------------
// Sacred or Secular (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Jaonus.
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

[QuestScript(90086)]
public class Quest90086Script : QuestScript
{
	protected override void Load()
	{
		SetId(90086);
		SetName("Sacred or Secular (1)");
		SetDescription("Talk to Believer Jaonus");

		AddPrerequisite(new LevelPrerequisite(292));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_25_4_SQ_30"));

		AddDialogHook("CATACOMB_25_4_SQ_JAUNIUS1", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_25_4_SQ_JAUNIUS1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_25_4_SQ_40_ST", "CATACOMB_25_4_SQ_40", "I don't understand.", "Not really my problem"))
		{
			case 1:
				// Func/SCR_CATACOMB_25_4_SQ_40_START;
				await dialog.Msg("FadeOutIN/2000");
				await dialog.Msg("BalloonText/CATACOMB_25_4_SQ_40_AG/7");
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
		character.Quests.Start("CATACOMB_25_4_SQ_50");
	}
}

