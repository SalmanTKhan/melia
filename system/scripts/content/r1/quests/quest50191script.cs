//--- Melia Script -----------------------------------------------------------
// Destroy the Demons' Device (2)
//--- Description -----------------------------------------------------------
// Quest to Destroy the Demon Device with the Bomb.
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

[QuestScript(50191)]
public class Quest50191Script : QuestScript
{
	protected override void Load()
	{
		SetId(50191);
		SetName("Destroy the Demons' Device (2)");
		SetDescription("Destroy the Demon Device with the Bomb");

		AddPrerequisite(new LevelPrerequisite(253));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_74_SQ7"));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 10120));

		AddDialogHook("TABLE74_SUBQ_ARTIFACT", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE74_SUBQ_ARTIFACT", "BeforeEnd", BeforeEnd);
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

		// Func/TABLE74_SUBQ8_COMPLETE;
		ZoneServer.Instance.World.FindNPC("TABLE74_SUBQ_ARTIFACT")?.PlayEffectLocal(character.Connection, "F_explosion006_orange1", 1f, "BOT");
		await dialog.Msg("NPCAin/TABLE74_SUBQ_ARTIFACT/DEAD/0");
		dialog.HideNPC("TABLE74_SUBQ_ARTIFACT");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You have destroyed the device.");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

