//--- Melia Script -----------------------------------------------------------
// Transmuter Furry Odd (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Transmuter Furry Odd.
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

[QuestScript(17018)]
public class Quest17018Script : QuestScript
{
	protected override void Load()
	{
		SetId(17018);
		SetName("Transmuter Furry Odd (2)");
		SetDescription("Talk to Transmuter Furry Odd");

		AddPrerequisite(new LevelPrerequisite(123));
		AddPrerequisite(new CompletedPrerequisite("FTOWER44_SQ_01"));

		AddObjective("collect0", "Collect 10 Hardened Black Crystal(s)", new CollectItemObjective("FTOWER44_SQ_02_01", 10));
		AddDrop("FTOWER44_SQ_02_01", 5f, 57220, 47401, 47396, 57050);

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3075));

		AddDialogHook("FTOWER44_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER44_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER44_SQ_02_ST", "FTOWER44_SQ_02", "I'll collect it so go ahead", "I can't because I have other things to do"))
		{
			case 1:
				await dialog.Msg("FTOWER44_SQ_02_AG");
				ZoneServer.Instance.World.FindNPC("FTOWER44_SQ_01")?.PlayEffectLocal(character.Connection, "F_pc_warp_circle", 0.5f, "BOT");
				dialog.HideNPC("FTOWER44_SQ_01");
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

		if (character.Inventory.HasItem("FTOWER44_SQ_02_01", 10))
		{
			character.Inventory.RemoveItem("FTOWER44_SQ_02_01", 10);
			await dialog.Msg("FTOWER44_SQ_02_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER44_SQ_03");
	}
}

