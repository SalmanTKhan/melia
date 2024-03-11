//--- Melia Script -----------------------------------------------------------
// The First Epitaph (1)
//--- Description -----------------------------------------------------------
// Quest to Inspect the lump of soil.
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

[QuestScript(40570)]
public class Quest40570Script : QuestScript
{
	protected override void Load()
	{
		SetId(40570);
		SetName("The First Epitaph (1)");
		SetDescription("Inspect the lump of soil");

		AddPrerequisite(new LevelPrerequisite(172));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5160));

		AddDialogHook("REMAINS37_2_HEAL", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_2_HEAL", "BeforeEnd", BeforeEnd);
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

		// Func/SCR_REMAINS37_2_SQ_010_SHOVEL_ANIMATION;
		ZoneServer.Instance.World.FindNPC("REMAINS37_2_HEAL")?.PlayEffectLocal(character.Connection, "I_smoke014_3", 1f, "BOT");
		dialog.HideNPC("REMAINS37_2_HEAL");
		await dialog.Msg("FadeOutIN/2500");
		dialog.UnHideNPC("REMAINS37_2_MT01");
		await Task.Delay(3000);
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "As you searched through the lump of soil, an overturned tombstone appeared!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

