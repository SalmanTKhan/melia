//--- Melia Script -----------------------------------------------------------
// This is Only the Beginning
//--- Description -----------------------------------------------------------
// Quest to Talk to Revelator Mihail.
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

[QuestScript(70448)]
public class Quest70448Script : QuestScript
{
	protected override void Load()
	{
		SetId(70448);
		SetName("This is Only the Beginning");
		SetDescription("Talk to Revelator Mihail");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CASTLE65_3_MQ08"));

		AddDialogHook("CASTLE653_MQ_07_2", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE653_MQ_09", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE653_MQ_09_start", "CASTLE65_3_MQ09", "Let's go back to Melchioras", "I'm going to rest for a while"))
		{
			case 1:
				dialog.HideNPC("CASTLE653_MQ_05_1");
				dialog.HideNPC("CASTLE653_MQ_06");
				dialog.HideNPC("CASTLE653_MQ_07_2");
				dialog.UnHideNPC("CASTLE653_MQ_04_1");
				dialog.UnHideNPC("CASTLE653_MQ_04_2");
				dialog.UnHideNPC("CASTLE653_MQ_09");
				await dialog.Msg("FadeOutIN/1000");
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

