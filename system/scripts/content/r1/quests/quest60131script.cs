//--- Melia Script -----------------------------------------------------------
// Into the Hands (6)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Irma.
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

[QuestScript(60131)]
public class Quest60131Script : QuestScript
{
	protected override void Load()
	{
		SetId(60131);
		SetName("Into the Hands (6)");
		SetDescription("Talk with Priest Irma");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PRISON622_MQ_02"));

		AddDialogHook("PRISON621_IRMA", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON623_IRMA_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON622_MQ_06_01", "PRISON622_MQ_06", "I will go right away", "I have some things to do first"))
		{
			case 1:
				dialog.UnHideNPC("PRISON623_GELIYA");
				await dialog.Msg("FadeOutIN/2500");
				dialog.HideNPC("PRISON621_IRMA");
				dialog.UnHideNPC("PRISON623_MQ_02_WALL");
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

