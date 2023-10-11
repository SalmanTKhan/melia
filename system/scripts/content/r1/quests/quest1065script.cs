//--- Melia Script -----------------------------------------------------------
// In their Honor (2)
//--- Description -----------------------------------------------------------
// Quest to Buy stonemason tools from the blacksmith in Klaipeda .
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

[QuestScript(1065)]
public class Quest1065Script : QuestScript
{
	protected override void Load()
	{
		SetId(1065);
		SetName("In their Honor (2)");
		SetDescription("Buy stonemason tools from the blacksmith in Klaipeda ");

		AddPrerequisite(new LevelPrerequisite(96));
		AddPrerequisite(new CompletedPrerequisite("ROKAS29_VACYS7"));
		AddPrerequisite(new ItemPrerequisite("Vis", 3000));

		AddDialogHook("BLACKSMITH", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS24_PIPOTI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS29_VACYS8_select1", "ROKAS29_VACYS8", "I'll pay 3,000 silver", "Tell him that it's too expensive"))
		{
			case 1:
				await dialog.Msg("ROKAS29_VACYS8_agree1");
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

		await dialog.Msg("ROKAS29_VACYS8_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS29_VACYS9");
	}
}

