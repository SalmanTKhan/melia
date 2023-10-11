//--- Melia Script -----------------------------------------------------------
// Into the Grip (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Pranas.
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

[QuestScript(60126)]
public class Quest60126Script : QuestScript
{
	protected override void Load()
	{
		SetId(60126);
		SetName("Into the Grip (1)");
		SetDescription("Talk with Priest Pranas");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PRISON621_MQ_04"));

		AddDialogHook("PRISON621_PRANAS", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON622_PRANAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON622_MQ_01_01", "PRISON622_MQ_01", "I will follow soon", "I still have other things to do"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/2500");
				dialog.HideNPC("PRISON621_PRANAS");
				dialog.UnHideNPC("PRISON622_PRANAS");
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


		return HookResult.Break;
	}
}

