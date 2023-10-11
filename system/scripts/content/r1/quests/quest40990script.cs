//--- Melia Script -----------------------------------------------------------
// What is the written on the pillar?
//--- Description -----------------------------------------------------------
// Quest to Look at the pillar.
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

[QuestScript(40990)]
public class Quest40990Script : QuestScript
{
	protected override void Load()
	{
		SetId(40990);
		SetName("What is the written on the pillar?");
		SetDescription("Look at the pillar");

		AddPrerequisite(new LevelPrerequisite(103));

		AddObjective("collect0", "Collect 13 Viscous Liquid(s)", new CollectItemObjective("ROKAS_36_1_SQ_050_ITEM_1", 13));
		AddDrop("ROKAS_36_1_SQ_050_ITEM_1", 10f, "Sec_chupacabra_desert");

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 2472));

		AddDialogHook("ROKAS_36_1_PILLA05", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_36_1_PILLA05", "BeforeEnd", BeforeEnd);
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

		if (character.Inventory.HasItem("ROKAS_36_1_SQ_050_ITEM_1", 13))
		{
			character.Inventory.RemoveItem("ROKAS_36_1_SQ_050_ITEM_1", 13);
			// Func/ROKAS_36_1_PILLA05_UNHIDE;
			await Task.Delay(2000);
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You can read the letters!");
			ZoneServer.Instance.World.FindNPC("ROKAS_36_1_PILLA05")?.PlayEffectLocal(character.Connection, "F_ground139_light_orange", 1f, "BOT");
			await Task.Delay(1000);
			await dialog.Msg("ROKAS_36_1_SQ_050_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

