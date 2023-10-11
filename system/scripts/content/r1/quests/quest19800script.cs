//--- Melia Script -----------------------------------------------------------
// Sanctuary of Truth or Lie? (3)
//--- Description -----------------------------------------------------------
// Quest to Look for the Symbol of Faith at the sanctum.
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

[QuestScript(19800)]
public class Quest19800Script : QuestScript
{
	protected override void Load()
	{
		SetId(19800);
		SetName("Sanctuary of Truth or Lie? (3)");
		SetDescription("Look for the Symbol of Faith at the sanctum");

		AddPrerequisite(new LevelPrerequisite(129));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM51_SQ_5_0"));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3225));

		AddDialogHook("PILGRIM51_SR03", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM51_SR03", "BeforeEnd", BeforeEnd);
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

		await Task.Delay(1000);
		ZoneServer.Instance.World.FindNPC("PILGRIM51_SR03")?.PlayEffectLocal(character.Connection, "I_spread_out001_light_fire", 2f, "TOP");
		await Task.Delay(2000);
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The Sanctum has been purified");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

