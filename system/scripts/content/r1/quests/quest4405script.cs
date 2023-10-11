//--- Melia Script -----------------------------------------------------------
// Old Owl Sculpture's Aid
//--- Description -----------------------------------------------------------
// Quest to Talk to the Old Owl Sculpture.
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

[QuestScript(4405)]
public class Quest4405Script : QuestScript
{
	protected override void Load()
	{
		SetId(4405);
		SetName("Old Owl Sculpture's Aid");
		SetDescription("Talk to the Old Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(123));
		AddPrerequisite(new CompletedPrerequisite("THORN23_Q_13"));

		AddObjective("collect0", "Collect 5 Infro Holder Horn(s)", new CollectItemObjective("THORN23_Thorn_1", 5));
		AddDrop("THORN23_Thorn_1", 3.5f, "Infroholder");

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("THORN23_OWL_ORB", 1));
		AddReward(new ItemReward("Vis", 3075));

		AddDialogHook("THORN23_OWL2", "BeforeStart", BeforeStart);
		AddDialogHook("THORN23_OWL2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN23_Q_15_select1", "THORN23_Q_15", "Ask what to do", "Ignore the Owl"))
		{
			case 1:
				await dialog.Msg("THORN23_Q_15_Q");
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

		if (character.Inventory.HasItem("THORN23_Thorn_1", 5))
		{
			character.Inventory.RemoveItem("THORN23_Thorn_1", 5);
			await dialog.Msg("THORN23_Q_15_succ1");
			ZoneServer.Instance.World.FindNPC("F_wizard_backmasking_light")?.PlayEffectLocal(character.Connection, "1");
			await Task.Delay(1300);
			await dialog.Msg("THORN23_Q_15_succ2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("THORN23_Q_16");
	}
}

