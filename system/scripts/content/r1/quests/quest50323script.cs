//--- Melia Script -----------------------------------------------------------
// I Can Hear You Singing (8)
//--- Description -----------------------------------------------------------
// Quest to Listen to the song with Indrea.
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

[QuestScript(50323)]
public class Quest50323Script : QuestScript
{
	protected override void Load()
	{
		SetId(50323);
		SetName("I Can Hear You Singing (8)");
		SetDescription("Listen to the song with Indrea");

		AddPrerequisite(new LevelPrerequisite(344));
		AddPrerequisite(new CompletedPrerequisite("WTREES22_1_SQ7"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 16512));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("WTREES221_SUBQ_NPC4", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES221_SUBQ_NPC4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES22_1_SUBQ8_START1", "WTREES22_1_SQ8", "Look around.", "I didn't get what you were saying. Good luck with that."))
		{
			case 1:
				await dialog.Msg("BalloonText/WTREES22_1_SUBQ8_INFOR1/3");
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

		await dialog.Msg("WTREES22_1_SUBQ8_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

