//--- Melia Script -----------------------------------------------------------
// The Keys Within the Spatial Gap
//--- Description -----------------------------------------------------------
// Quest to Talk to Morkus Jonas.
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

[QuestScript(1072)]
public class Quest1072Script : QuestScript
{
	protected override void Load()
	{
		SetId(1072);
		SetName("The Keys Within the Spatial Gap");
		SetDescription("Talk to Morkus Jonas");

		AddPrerequisite(new LevelPrerequisite(64));
		AddPrerequisite(new CompletedPrerequisite("ROKAS25_TO_26"));

		AddReward(new ExpReward(42210, 42210));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 19456));

		AddDialogHook("ROKAS26_MQ1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS26_MQ1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS26_MQ1_select1", "ROKAS26_MQ1", "I'll find the keys", "I'd like to stop"))
		{
			case 1:
				dialog.UnHideNPC("ROKAS26_MQ1_STONE");
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

		if (character.Inventory.HasItem("ROKAS26_MQ1_key", 3))
		{
			character.Inventory.RemoveItem("ROKAS26_MQ1_key", 3);
			dialog.HideNPC("ROKAS26_MQ1_STONE");
			await dialog.Msg("ROKAS26_MQ1_end1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

