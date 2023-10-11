//--- Melia Script -----------------------------------------------------------
// The Black Crystal's identity
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Stella.
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

[QuestScript(70565)]
public class Quest70565Script : QuestScript
{
	protected override void Load()
	{
		SetId(70565);
		SetName("The Black Crystal's identity");
		SetDescription("Talk to Monk Stella");

		AddPrerequisite(new LevelPrerequisite(268));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_3_SQ05"));

		AddDialogHook("PILGRIM413_SQ_06", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM413_SQ_06", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM413_SQ_06_start", "PILGRIM41_3_SQ06", "Tell her to wait here a while", "Say that she should do the talking herself"))
		{
			case 1:
				await dialog.Msg("PILGRIM413_SQ_06_agree");
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

		await dialog.Msg("PILGRIM413_SQ_06_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

