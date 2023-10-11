//--- Melia Script -----------------------------------------------------------
// Disaster of Saknis Plains (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Senior Officer Philipas.
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

[QuestScript(8265)]
public class Quest8265Script : QuestScript
{
	protected override void Load()
	{
		SetId(8265);
		SetName("Disaster of Saknis Plains (1)");
		SetDescription("Talk to Senior Officer Philipas");

		AddPrerequisite(new LevelPrerequisite(114));
		AddPrerequisite(new CompletedPrerequisite("KATYN14_MQ_18"));
		AddPrerequisite(new ItemPrerequisite("KATYN14_MQ_16_ITEM", -100));

		AddDialogHook("KATYN14_VACENIN", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN14_VACENIN_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN14_MQ_24_01", "KATYN14_MQ_24", "Let's follow to Isdaigininko Highway", "I need some time to prepare"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/1000");
				dialog.HideNPC("KATYN14_VACENIN");
				dialog.HideNPC("KATYN14_PIL_SOL");
				dialog.UnHideNPC("KATYN14_VACENIN_AFTER");
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

		await dialog.Msg("KATYN14_MQ_24_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN14_MQ_25");
	}
}

