//--- Melia Script -----------------------------------------------------------
// Lost Material (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Necromancer Drasius.
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

[QuestScript(20224)]
public class Quest20224Script : QuestScript
{
	protected override void Load()
	{
		SetId(20224);
		SetName("Lost Material (2)");
		SetDescription("Talk to Necromancer Drasius");

		AddPrerequisite(new LevelPrerequisite(99));
		AddPrerequisite(new CompletedPrerequisite("REMAIN38_SQ01"));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1980));

		AddDialogHook("REMAIN38_SQ_DRASIUS", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN38_SQ_DRASIUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAIN38_SQ02_select01", "REMAIN38_SQ02", "I want to watch the calling of evil spirits", "About the Land with story", "I don't really want to"))
		{
			case 1:
				await dialog.Msg("REMAIN38_SQ02_AG");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("REMAIN38_SQ02_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("REMAIN38_SQ02_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

