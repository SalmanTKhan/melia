//--- Melia Script -----------------------------------------------------------
// Meeting the Abbot
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Natasha.
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

[QuestScript(70145)]
public class Quest70145Script : QuestScript
{
	protected override void Load()
	{
		SetId(70145);
		SetName("Meeting the Abbot");
		SetDescription("Talk to Hunter Natasha");

		AddPrerequisite(new LevelPrerequisite(179));
		AddPrerequisite(new CompletedPrerequisite("THORN39_3_MQ05"));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5370));

		AddDialogHook("THORN393_MQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY394_MQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_3_MQ_06_1", "THORN39_3_MQ06", "I'll go there", "About the chase of Ebonypawn", "Tell him that you need some time to think"))
		{
			case 1:
				dialog.HideNPC("THORN392_MQ_02");
				dialog.HideNPC("THORN392_MQ_03");
				dialog.HideNPC("THORN392_MQ_02_COMPANION");
				dialog.HideNPC("THORN391_MQ_01");
				dialog.HideNPC("THORN391_MQ_02");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("THORN39_3_MQ_06_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("THORN39_3_MQ_06_4");
		dialog.HideNPC("THORN393_MQ_01");
		dialog.HideNPC("THORN393_MQ_03");
		dialog.HideNPC("THORN393_COMPANION");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

