//--- Melia Script -----------------------------------------------------------
// The Corrupted Lake (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Elder's Granddaughter.
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

[QuestScript(90005)]
public class Quest90005Script : QuestScript
{
	protected override void Load()
	{
		SetId(90005);
		SetName("The Corrupted Lake (6)");
		SetDescription("Talk to the Elder's Granddaughter");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_83_MQ_04"));

		AddDialogHook("3CMLAKE_83_LADY", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_84_OLDMAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE_83_MQ_05_DLG_05", "F_3CMLAKE_83_MQ_05", "Read the diary to me", "Read it to me later"))
		{
			case 1:
				await dialog.Msg("3CMLAKE_83_MQ_05_DLG_01");
				await dialog.Msg("CameraShockWaveLocal/2/99999/2/1/100/0");
				await dialog.Msg("BalloonText/3CMLAKE_83_BALLOON/2");
				await Task.Delay(500);
				await dialog.Msg("3CMLAKE_83_MQ_05_DLG_04");
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

