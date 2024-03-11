//--- Melia Script -----------------------------------------------------------
// Information about Saugas (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Mercenary Eta.
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

[QuestScript(8045)]
public class Quest8045Script : QuestScript
{
	protected override void Load()
	{
		SetId(8045);
		SetName("Information about Saugas (2)");
		SetDescription("Talk to Mercenary Eta");

		AddPrerequisite(new LevelPrerequisite(64));
		AddPrerequisite(new CompletedPrerequisite("ROKAS26_SUB_Q08"));

		AddObjective("collect0", "Collect 3 Monster Poison(s)", new CollectItemObjective("ROKAS26_SAURBLOOD", 3));
		AddDrop("ROKAS26_SAURBLOOD", 3f, 41446, 57038, 57621, 57619);

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("ROKAS26_EHTA", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS26_EHTA", "BeforeEnd", BeforeEnd);
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

		if (character.Inventory.HasItem("ROKAS26_SAURBLOOD", 3))
		{
			character.Inventory.RemoveItem("ROKAS26_SAURBLOOD", 3);
			await dialog.Msg("ROKAS26_SUB_Q09_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		character.AddonMessage(AddonMessage.NOTICE_Dm_Exclaimation, "You need poison from monsters to amplify the energy of the stones!", 8);
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS26_SUB_Q10");
	}
}

