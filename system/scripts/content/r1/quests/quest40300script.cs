//--- Melia Script -----------------------------------------------------------
// Unexpected Discovery (3)
//--- Description -----------------------------------------------------------
// Quest to Investigate the Wooden Wine Cask.
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

[QuestScript(40300)]
public class Quest40300Script : QuestScript
{
	protected override void Load()
	{
		SetId(40300);
		SetName("Unexpected Discovery (3)");
		SetDescription("Investigate the Wooden Wine Cask");

		AddPrerequisite(new LevelPrerequisite(89));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("FARM47_2_SQ_030_ITEM_1", 1));
		AddReward(new ItemReward("Vis", 1780));

		AddDialogHook("FARM47_DRUM02_D", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_DRUM02_D", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		ZoneServer.Instance.World.FindNPC("FARM47_DRUM02_D")?.PlayEffectLocal(character.Connection, "I_smoke005_dark", 1f, "BOT");
		dialog.HideNPC("FARM47_DRUM02_D");
		await dialog.Msg("FadeOutIN/2000");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "As the cask opened, the lower part of the small sculpture has appeared");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

